using UnityEngine;

public class EtatMort : EtatEnnemi
{
    private float tempsAvantDetruire = 2.0f;
    private float tempsEcoule = 0.0f;

    public EtatMort(ComportementEnnemi squelette) : base(squelette)
    {
        sujet.agent.enabled = false;        
    }

    public override void Entrer()
    {
        GameObject.Destroy(sujet.GetComponent<Collider>());   // Pour éviter les collisions avec le squelette mort
    }

    public override void Executer(float deltaTime)
    {
        // Petite animation de mort: le squelette tourne en rond, puis disparait
        tempsEcoule += deltaTime;
        sujet.transform.Rotate(Vector3.up, 180.0f * deltaTime);
        if (tempsEcoule >= tempsAvantDetruire)
        {
            GameObject.Destroy(sujet.gameObject);
        }
    }

    public override void Sortir()
    {
    }
}
