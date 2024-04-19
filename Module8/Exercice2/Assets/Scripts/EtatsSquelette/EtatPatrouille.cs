using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EtatPatrouille : EtatSquelette
{
    private LogiquePatrouille _patrouille;
    //private Transform[] _points;
    //private int _indexPatrouille; 

    public EtatPatrouille(MouvementSquelette squelette, GameObject joueur, Transform[] points) : base(squelette, joueur)
    {
        _patrouille = new LogiquePatrouille(points);
    }


    public override void Enter()
    {
        Animateur.SetBool("Walk", true);
    }

    public override void Handle(float deltaTime)
    {
        if (! AgentMouvement.pathPending)
        {
            if (AgentMouvement.remainingDistance <= 0.1f)
            {
                _patrouille.PasserAuPointSuivant();
                AgentMouvement.destination = _patrouille.PointCourant;
            }
        }

        if (JoueurVisible())
        {
            MouvementSquelette mouvement = Squelette.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.Poursuite);
        }

    }

    public override void Leave()
    {
        Animateur.SetBool("Walk", false);
    }
}

