using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EtatPoursuiteSquelette : EtatSquelette
{

    public EtatPoursuiteSquelette(GameObject sujet, GameObject joueur) : base(sujet, joueur)
    {

    }

    public override void Enter()
    {
        Animateur.SetBool("Walk", true);
        AgentMouvement.destination = Joueur.transform.position;  // Patch car le joueur est à y == 1
    }

    public override void Handle(float deltaTime)
    {
        if (!JoueurVisible())
        {
            MouvementSquelette mouvement = Sujet.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.EtatAttente);
        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Walk", false);

    }
}

