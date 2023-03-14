using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class EtatAttenteSquelette : EtatSquelette
{
    private float _timeRemaining;
    public EtatAttenteSquelette(GameObject sujet, GameObject joueur) : base(sujet, joueur)
    {
        _timeRemaining = 0.0f;
    }

    public override void Enter()
    {
        _timeRemaining = UnityEngine.Random.Range(3.0f, 5.0f);
    }

    public override void Handle(float deltaTime)
    {
        _timeRemaining -= deltaTime;
        if (_timeRemaining < 0.0f)
        {
            MouvementSquelette mouvement = Sujet.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.EtatMouvement);
        }
        else if (JoueurVisible())
        {
            MouvementSquelette mouvement = Sujet.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.EtatPoursuite);
        }
    }

    public override void Leave()
    {
    }

}

