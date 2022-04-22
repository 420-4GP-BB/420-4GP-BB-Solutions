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
    
    public EtatPatrouille(GameObject sujet, Transform[] trajetPatrouille, GameObject joueur) : base(sujet, joueur)
    {
        _pointsPatrouille = new PointsPatrouille(trajetPatrouille);
        //objectifs = lesPoints;
        //indiceObjectifs = 0;
    }

    public override void Enter()
    {
        Animateur.SetBool("Run", true);
        AgentMouvement.SetDestination(_pointsPatrouille.Destination.position);
    }

    public override void Handle()
    {
        bool visible = JoueurVisible();

        if (visible)
        {
            Sujet.GetComponent<MouvementEnnemi>().ChangerEtat(new EtatPoursuite(Sujet, Joueur));
        }
        else
        {
            Vector3 positionActuelle = Sujet.transform.position;
            if (! AgentMouvement.pathPending && AgentMouvement.remainingDistance <= AgentMouvement.stoppingDistance)
            {
                _pointsPatrouille.PasserAuProchain();
                AgentMouvement.SetDestination(_pointsPatrouille.Destination.position);
            }
        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Run", false);
    }
}
