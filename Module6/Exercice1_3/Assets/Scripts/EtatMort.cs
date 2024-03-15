using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EtatMort : EtatSquelette
{
    private float temps;
    
    public EtatMort(MouvementSquelette squelette, GameObject joueur) : base(squelette, joueur)
    {
    }

    public override void Enter()
    {
        AgentMouvement.enabled = false;
        temps = 0.0f;
    }

    public override void Handle(float deltaTime)
    {
        temps += deltaTime;
        if (temps >= 3.0f)
        {
            GameObject.Destroy(Squelette.gameObject);
        }
    }

    public override void Leave()
    {
    }   
}
