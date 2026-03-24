using UnityEngine;

public class EtatPoursuite : EtatEnnemi
{
    public EtatPoursuite(ComportementEnnemi comportementEnnemi) : base(comportementEnnemi)
    { }

    public override void Entrer()
    {
        sujet.animateur.SetBool("Walk", true);
        sujet.agent.SetDestination(sujet.joueur.transform.position);

        sujet.agent.isStopped = false;
    }

    public override void Executer(float deltaTime)
    {
        Vector3 positionJoueur = sujet.joueur.transform.position;
        Vector3 positionEnnemi = sujet.transform.position;
        float distanceJoueur = (positionJoueur - positionEnnemi).magnitude;

        if (distanceJoueur < 2.5f)
        {
            sujet.ChangerEtat(sujet.etatAttaque);
        }
        else if (!sujet.JoueurVisible())
        {
            sujet.ChangerEtat(sujet.etatAttente);
        }
        else
        {
            sujet.agent.SetDestination(positionJoueur);
        }
    }
}
