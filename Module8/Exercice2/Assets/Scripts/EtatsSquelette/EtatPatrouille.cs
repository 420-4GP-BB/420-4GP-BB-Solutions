using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EtatPatrouille : EtatSquelette
{
    private LogiquePatrouille _logiquePatrouille;

    public EtatPatrouille(MouvementSquelette squelette, GameObject joueur, Transform[] points) : base(squelette, joueur)
    {
        _logiquePatrouille = new LogiquePatrouille(points);
    }

    public override void Enter()
    {
        Animateur.SetBool("Walk", true);
        AgentMouvement.destination = _logiquePatrouille.PointCourant;
    }

    public override void Handle(float deltaTime)
    {
        if (! AgentMouvement.pathPending)
        {
            if (AgentMouvement.remainingDistance <= 0.1f)
            {
                _logiquePatrouille.PasserAuPointSuivant();
                AgentMouvement.destination = _logiquePatrouille.PointCourant;
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

