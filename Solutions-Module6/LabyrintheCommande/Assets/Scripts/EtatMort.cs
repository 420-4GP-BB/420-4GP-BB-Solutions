using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatMort : EtatMouvementEnnemi
{

    public EtatMort(MouvementEnnemi ennemi, GameObject joueur) : base(ennemi, joueur)
    {
        
    }

    public override void Deplacer()
    {
        Agent.speed = 0;
        Agent.velocity = Vector3.zero;
    }
}
