using UnityEngine;

namespace EtatsPoule
{
    /**
     * Poule calme. Elle avance/recule tranquillement.
     */
    public class EtatCalme : EtatPoule
    {
        private bool _droite;
        private float _largeurDeplacement = 2.5f;

        public EtatCalme(Poule sujet) : base(sujet)
        {
        }

        public override void Enter()
        {
            Sujet.Animator.SetFloat("Vitesse", 0.5f);
        }

        public override void Handle()
        {
            var direction = Vector3.right;

            if (!_droite)
            {
                direction = -Vector3.right;
            }

            var vitesse = Sujet.Vitesse * direction;
            var deplacement = vitesse * Time.deltaTime;

            var prochainePosition = Sujet.transform.position + deplacement;

            if (Vector3.Distance(prochainePosition, Sujet.PositionCentre) < _largeurDeplacement)
            {
                Sujet.transform.position = prochainePosition;
                Sujet.transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            }
            else
            {
                _droite = !_droite;
                Sujet.transform.position = Vector3.MoveTowards(
                    Sujet.transform.position,
                    Sujet.PositionCentre,
                    Sujet.Vitesse * Time.deltaTime);
                Sujet.transform.LookAt(Sujet.PositionCentre, Vector3.up);
            }
        }

        public override void Exit()
        {
        }


        public override void Heurter()
        {
            Sujet.ChangerEtat(new EtatAgitee(Sujet));
        }
    }
}