using UnityEngine;

namespace EtatsPoule
{
    public class EtatAgitee : EtatPoule
    {
        private Vector3 objectif;
        private int _nbCoups;
        private float tempsDansEtat = 0;
        private float tempsAvantCalme = 3f;

        public EtatAgitee(Poule sujet) : base(sujet)
        {
            objectif = Sujet.PositionCentre + new Vector3(2.5f, 0, 1f);
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

            // La poule a peur, elle court vers un endroit pour se cacher
            var vitesse = Sujet.Vitesse * 2f;

            Sujet.transform.position = Vector3.MoveTowards(
                Sujet.transform.position,
                objectif, vitesse * Time.deltaTime);

            Sujet.transform.LookAt(objectif * 1.1f);
        }

        public override void Exit()
        {
        }


        public override void Heurter()
        {
            // Remise à zéro du compteur
            tempsDansEtat = 0;

            _nbCoups++;

            // Après trois coups, la poule se fâche et va 
            if (_nbCoups > 3)
            {
                Sujet.ChangerEtat(new EtatAttaque(Sujet));
            }
        }
    }
}