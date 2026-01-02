using UnityEngine;

namespace EtatsPoule
{
    public abstract class EtatPoule
    {
        protected Poule Sujet;

        protected EtatPoule(Poule sujet)
        {
            Sujet = sujet;
        }

        public abstract void Enter();
        public abstract void Handle();
        public abstract void Exit();

        public virtual void Heurter()
        {
            // Rien à faire par défaut
        }
    }
}