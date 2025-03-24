using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class EtatAttente : EtatSquelette
{
    private float _tempAttente;

    public EtatAttente(MouvementSquelette squelette, GameObject joueur) : base(squelette, joueur)
    {
        _tempAttente = 0.0f;
    }

    public override void Enter()
    {
        _tempAttente = UnityEngine.Random.Range(3.0f, 5.0f);
        AgentMouvement.destination = Squelette.transform.position;
    }

    public override void Handle(float deltaTime)
    {
        _tempAttente -= deltaTime;
        if (_tempAttente < 0.0f)
        {
            MouvementSquelette mouvement = Squelette.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.Patrouille);
        }
        else if (JoueurVisible())
        {
            MouvementSquelette mouvement = Squelette.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.Poursuite);
        }
    }

    public override void Leave()
    {
    }

}

