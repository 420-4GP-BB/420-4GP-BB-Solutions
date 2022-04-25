using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatAttente : EtatMouvement
{
    private float tempsAccumule;
    private float tempsLimite;

    public EtatAttente(GameObject sujet, GameObject joueur, IChangementDestination dest) : base(sujet, joueur, dest)
    {

    }
         
    public override void Enter()
    {
        Debug.Log("Entre en attente");
        tempsAccumule = 0.0f;
        tempsLimite = Random.Range(3, 6);
        Debug.Log("Position: " + Sujet.transform.position.ToString());
        ChangementDestination.Agent.enabled = false;
//        AgentMouvement.SetDestination(Sujet.transform.position);
    }

    public override void Handle()
    {
        bool visible = JoueurVisible();
        tempsAccumule += Time.deltaTime;

        if (visible)
        {
            Sujet.GetComponent<MouvementEnnemi>().ChangerEtat(new EtatPoursuite(Sujet, Joueur, ChangementDestination));
        }
        else if (tempsAccumule >= tempsLimite)
        {
            Debug.Log("Temps accumule: " + tempsAccumule.ToString());
            MouvementEnnemi patrouille = Sujet.GetComponent<MouvementEnnemi>();
            patrouille.ChangerEtat(patrouille.Patrouille);
        }
    }

    public override void Leave()
    {
        Debug.Log("Sort de l'attente");
        Debug.Log("Position: " + Sujet.transform.position.ToString());
        ChangementDestination.Agent.enabled = true;
    }
}
