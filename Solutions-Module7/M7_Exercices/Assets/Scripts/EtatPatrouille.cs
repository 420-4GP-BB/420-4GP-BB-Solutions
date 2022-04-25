using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EtatPatrouille : EtatMouvement
{
    private PointsPatrouille _pointsPatrouille;
    
    public EtatPatrouille(GameObject sujet, Transform[] trajetPatrouille, GameObject joueur, IChangementDestination dest) : base(sujet, joueur, dest)
    {
        _pointsPatrouille = new PointsPatrouille(trajetPatrouille);
    }

    public override void Enter()
    {
        Animateur.SetBool("Run", true);
        ChangementDestination.ChangerPositionCible(_pointsPatrouille.Destination.position);
    }

    public override void Handle()
    {
        bool visible = JoueurVisible();

        if (visible)
        {
            Sujet.GetComponent<MouvementEnnemi>().ChangerEtat(new EtatPoursuite(Sujet, Joueur, ChangementDestination));
        }
        else
        {
            Vector3 positionActuelle = Sujet.transform.position;
            if (ChangementDestination.DestinationAtteinte())
            {
                _pointsPatrouille.PasserAuProchain();
                ChangementDestination.ChangerPositionCible(_pointsPatrouille.Destination.position);
            }
        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Run", false);
    }
}
