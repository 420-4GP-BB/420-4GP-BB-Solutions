using UnityEngine;

public class EtatAttente : EtatEnnemi
{
    public EtatAttente(ComportementEnnemi comportementEnnemi) : base(comportementEnnemi)
    { }

    private float tempsAttente = 0f;

    public override void Entrer()
    {
        sujet.animateur.SetBool("Walk", false);
        sujet.agent.isStopped = true;

        tempsAttente = Random.Range(3f, 5f);
    }

    public override void Executer(float deltaTime)
    {
        tempsAttente -= deltaTime;
        if (tempsAttente < 0f)
        {
            sujet.ChangerEtat(sujet.etatPatrouille);
        }
    }
}
