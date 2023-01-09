using System;
using UnityEngine;
using UnityEngine.AI;

public class EtatPoursuite : EtatMouvement
{
    public EtatPoursuite(GameObject sujet, GameObject joueur) : base(sujet, joueur)
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
            Sujet.GetComponent<MouvementEnnemi>().ChangerEtat(new EtatAttente(Sujet, Joueur));
        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Run", false);
    }
}

