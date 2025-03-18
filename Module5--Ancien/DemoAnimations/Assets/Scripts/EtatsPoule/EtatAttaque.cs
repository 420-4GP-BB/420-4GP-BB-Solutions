using UnityEngine;

namespace EtatsPoule
{
    public class EtatAttaque : EtatPoule
    {
        private float tempsDansEtat = 0;
        private float tempsAvantCalme = 3f;
        private bool attaqueCompletee;

        public EtatAttaque(Poule sujet) : base(sujet)
        {
        }

        public override void Enter()
        {
            // Course
            Sujet.Animator.SetFloat("Vitesse", 2f);
        }

        public override void Handle()
        {
            tempsDansEtat += Time.deltaTime;

            // Après un certain temps à avoir peur, elle se calme d'elle-même
            if (tempsDansEtat > tempsAvantCalme)
            {
                Sujet.ChangerEtat(new EtatCalme(Sujet));
                return;
            }

            // La poule est fâchée!
            var vitesse = Sujet.Vitesse * 3f;

            if (!attaqueCompletee)
            {
                if (Vector3.Distance(Sujet.transform.position, Sujet.Cible.transform.position) > 0.7f)
                {
                    Sujet.transform.position = Vector3.MoveTowards(
                        Sujet.transform.position,
                        Sujet.Cible.transform.position,
                        vitesse * Time.deltaTime);
                    Sujet.transform.LookAt(Sujet.Cible.transform.position);
                }
                else
                {
                    // Si la poule est assez proche de sa cible, elle contre-attaque!
                    attaqueCompletee = true;
                    Sujet.Attaquer();
                }
            }
            else if (Vector3.Distance(Sujet.transform.position, Sujet.PositionCentre) > 0.1f)
            {
                // Retourner au centre du terrain, puis redevenir calme
                Sujet.transform.position = Vector3.MoveTowards(
                    Sujet.transform.position,
                    Sujet.PositionCentre,
                    vitesse * Time.deltaTime);
                Sujet.transform.LookAt(Sujet.PositionCentre);
            }
            else
            {
                // Poule retournée au centre: on revient au calme
                Sujet.ChangerEtat(new EtatCalme(Sujet));
            }
        }

        public override void Exit()
        {
        }


        public override void Heurter()
        {
            // Remise à zéro du compteur
            tempsDansEtat = 0;
        }
    }
}