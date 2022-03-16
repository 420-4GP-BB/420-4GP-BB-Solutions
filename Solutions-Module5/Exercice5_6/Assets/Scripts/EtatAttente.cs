using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EtatAttente : EtatMouvement
{
    private float tempsAccumule;
    private float tempsLimite;

    public EtatAttente(GameObject sujet, GameObject joueur) : base(sujet, joueur)
    {

    }
         
    public override void Enter()
    {
        Debug.Log("Entre en attente");
        tempsAccumule = 0.0f;
        tempsLimite = Random.Range(3, 6);
        Debug.Log("Position: " + Sujet.transform.position.ToString());
        AgentMouvement.enabled = false;
//        AgentMouvement.SetDestination(Sujet.transform.position);
    }

    public override void Handle()
    {
        bool visible = JoueurVisible();
        tempsAccumule += Time.deltaTime;

        if (visible)
        {
            Sujet.GetComponent<PatrouilleExercice6>().ChangerEtat(new EtatPoursuite(Sujet, Joueur));
        }
        else if (tempsAccumule >= tempsLimite)
        {
            Debug.Log("Temps accumule: " + tempsAccumule.ToString());
            PatrouilleExercice6 patrouille = Sujet.GetComponent<PatrouilleExercice6>();
            patrouille.ChangerEtat(patrouille.Patrouille);
        }
    }

    public override void Leave()
    {
        Debug.Log("Sort de l'attente");
        Debug.Log("Position: " + Sujet.transform.position.ToString());
        AgentMouvement.enabled = true;
    }
}
