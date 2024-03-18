using UnityEngine;

public class EtatAttaque : EtatSquelette
{

    public EtatAttaque(MouvementSquelette p_squelette, GameObject joueur) : base(p_squelette, joueur)
    {
    }

    public override void Enter()
    {
        Animateur.SetBool("Attack", true);
    }

    public override void Handle(float deltaTime)
    {
    }

    public override void Leave()
    {
        Animateur.SetBool("Attack", false);
    }
}

