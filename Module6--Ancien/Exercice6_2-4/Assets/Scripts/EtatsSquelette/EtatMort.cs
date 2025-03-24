using UnityEngine;

public class EtatMort : EtatSquelette
{
    private float tempsAvantDetruire = 2.0f;
    private float tempsEcoule = 0.0f;

    public EtatMort(MouvementSquelette squelette, GameObject joueur) : base(squelette, joueur)
    {
        AgentMouvement.enabled = false;        
    }

    public override void Enter()
    {
        GameObject.Destroy(Squelette.GetComponent<Collider>());   // Pour éviter les collisions avec le squelette mort
    }

    public override void Handle(float deltaTime)
    {
        tempsEcoule += deltaTime;
        Squelette.transform.Rotate(Vector3.up, 180.0f * deltaTime);
        if (tempsEcoule >= tempsAvantDetruire)
        {
            GameObject.Destroy(Squelette.gameObject);
        }
    }

    public override void Leave()
    {
    }
}
