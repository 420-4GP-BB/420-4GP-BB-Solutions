using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EtatPoursuite : EtatSquelette
{

    public EtatPoursuite(MouvementSquelette squelette, GameObject joueur) : base(squelette, joueur)
    {

    }

    public override void Enter()
    {
        Animateur.SetBool("Walk", true);
//        Vector3 destination = new Vector3(Joueur.transform.position.x, Squelette.gameObject.transform.position.y,
//            Joueur.transform.position.z);
        AgentMouvement.destination = Joueur.transform.position;  // Patch car le joueur est à y == 1
    }

    public override void Handle(float deltaTime)
    {
        bool attaque_requise = false;
        if (!JoueurVisible())
        {
            MouvementSquelette mouvement = Squelette.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.Attente);
        }
        else
        {
            AgentMouvement.destination = Joueur.transform.position;
            attaque_requise = Vector3.Distance(Squelette.transform.position, Joueur.transform.position) <= 3.0f;
        }
        
        if (attaque_requise)
        {
          Squelette.ChangerEtat(new EtatAttaque(Squelette, Joueur));
          // Animateur.SetBool("Attack", attaque_requise);
        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Walk", false);

    }
}

