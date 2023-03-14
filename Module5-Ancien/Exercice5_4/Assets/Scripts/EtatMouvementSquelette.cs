using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EtatMouvementSquelette : EtatSquelette
{
    private Transform[] _points;
    private int _indexPatrouille; 

    public EtatMouvementSquelette(GameObject sujet, GameObject joueur, Transform[] points) : base(sujet, joueur)
    {
        _points = points;
        _indexPatrouille = 0;
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
                AgentMouvement.destination = _points[_indexPatrouille].position;
                _indexPatrouille = (_indexPatrouille + 1) % _points.Length;
            }
        }

        if (JoueurVisible())
        {
            MouvementSquelette mouvement = Sujet.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.EtatPoursuite);
        }

    }

    public override void Leave()
    {
        Animateur.SetBool("Walk", false);
    }
}

