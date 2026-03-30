using UnityEngine;

public class EtatMort : EtatEnnemi
{
    private float vitesseAngulaire = 180f;
    private float tempsAvantDetruire = 2f;

    public EtatMort(ComportementEnnemi squelette) : base(squelette)
    { }

    public override void Entrer()
    {
        sujet.agent.enabled = false;

        // Pour eviter les collisions avec le squelette mort
        GameObject.Destroy(sujet.squeletteCollider);   
    }

    public override void Executer(float deltaTime)
    {
        // Petite animation de mort: le squelette tourne en rond, puis disparait
        sujet.transform.Rotate(new Vector3(0f, 1f, 0f) * vitesseAngulaire * deltaTime);

        tempsAvantDetruire -= deltaTime;
        if (tempsAvantDetruire <= 0)
        {
            GameObject.Destroy(sujet.gameObject);
        }
    }
}
