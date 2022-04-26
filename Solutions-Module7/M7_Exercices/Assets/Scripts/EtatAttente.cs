using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatAttente : EtatMouvement
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
        ChangementDestination.Arreter();
    }

    public override void Handle()
    {
        bool visible = JoueurVisible();
        tempsAccumule += Time.deltaTime;

        if (visible)
        {
            Sujet.GetComponent<MouvementEnnemi>().ChangerEtat(new EtatPoursuite(Sujet, Joueur));
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
        ChangementDestination.Reprendre();
    }
}
