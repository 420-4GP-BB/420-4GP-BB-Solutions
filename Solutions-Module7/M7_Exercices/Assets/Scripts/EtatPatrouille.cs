using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EtatPatrouille : EtatMouvement
{
    private PointsPatrouille _pointsPatrouille;

    //private Transform[] objectifs;
    //private int indiceObjectifs;
    //private bool aller;
    
    public EtatPatrouille(GameObject sujet, Transform[] trajetPatrouille, GameObject joueur, IChangementDestination dest) : base(sujet, joueur, dest)
    {
        _pointsPatrouille = new PointsPatrouille(trajetPatrouille);
        //objectifs = lesPoints;
        //indiceObjectifs = 0;
    }

    public override void Enter()
    {
        Animateur.SetBool("Run", true);
        ChangementDestination.ChangerDestination(_pointsPatrouille.Destination);
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
            if (! ChangementDestination.Agent.pathPending && ChangementDestination.Agent.remainingDistance <= ChangementDestination.Agent.stoppingDistance)
            {
                _pointsPatrouille.PasserAuProchain();
                ChangementDestination.Agent.SetDestination(_pointsPatrouille.Destination.position);
            }
        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Run", false);
    }
}
