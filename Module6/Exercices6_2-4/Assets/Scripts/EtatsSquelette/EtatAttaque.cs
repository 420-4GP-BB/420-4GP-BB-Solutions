using UnityEngine;

public class EtatAttaque : EtatEnnemi
{
    public EtatAttaque(ComportementEnnemi comportementEnnemi) : base(comportementEnnemi)
    { }

    public override void Entrer()
    {
        sujet.animateur.SetTrigger("Attack");
        sujet.agent.isStopped = true;
    }

    public override void Executer(float deltaTime)
    {
        Vector3 positionJoueur = sujet.joueur.transform.position;
        Vector3 positionEnnemi = sujet.transform.position;
        float distanceJoueur = (positionJoueur - positionEnnemi).magnitude;

        if (distanceJoueur > 2.5f)
        {
            sujet.ChangerEtat(sujet.etatPatrouille);
        }
    }
}
