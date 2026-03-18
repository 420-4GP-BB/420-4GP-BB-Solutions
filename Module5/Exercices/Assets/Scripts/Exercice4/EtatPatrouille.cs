using UnityEngine;

public class EtatPatrouille : EtatEnnemi
{
    public EtatPatrouille(ComportementEnnemi comportementEnnemi) : base(comportementEnnemi)
    { }

    public override void Entrer()
    {
        sujet.animateur.SetBool("Walk", true);
        ChoisirPointAleatoire();

        sujet.agent.isStopped = false;
    }

    public override void Executer(float deltaTime)
    {
        if (sujet.JoueurVisible())
        {
            sujet.ChangerEtat(sujet.etatPoursuite);
        }
        else if (sujet.agent.remainingDistance < 0.5f)
        {
            ChoisirPointAleatoire();
        }
    }

    private void ChoisirPointAleatoire()
    {
        int nombreAleatoire = Random.Range(0, sujet.pointPatrouilles.Count);
        Vector3 pointSelectionne = sujet.pointPatrouilles[nombreAleatoire].transform.position;
        sujet.agent.SetDestination(pointSelectionne);
    }
}
