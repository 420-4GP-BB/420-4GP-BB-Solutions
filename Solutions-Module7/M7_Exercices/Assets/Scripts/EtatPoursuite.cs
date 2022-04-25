using System;
using UnityEngine;
using UnityEngine.AI;

public class EtatPoursuite : EtatMouvement
{
    public EtatPoursuite(GameObject sujet, GameObject joueur, IChangementDestination dest) : base(sujet, joueur, dest)
    {
    }

    public override void Enter()
    {
        ChangementDestination.ChangerPositionCible(Joueur.transform.position);
        Animateur.SetBool("Run", true);
    }

    public override void Handle()
    {
        bool visible = JoueurVisible();

        if (visible)
        {
            ChangementDestination.ChangerPositionCible(Joueur.transform.position);
        }
        else if (ChangementDestination.DestinationAtteinte())
        {
            // On est rendu au dernier endroit où on a vu le joueur. On attends
            Sujet.GetComponent<MouvementEnnemi>().ChangerEtat(new EtatAttente(Sujet, Joueur, ChangementDestination));
        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Run", false);
    }
}

