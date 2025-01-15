using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Classe qui permet de d�tecter qu'on a atteint l'objectif.
 * Elle replace le joueur � sa position initiale.
 *
 * Auteur: �ric Wenaas
 */
public class DetectionFin : MonoBehaviour
{
    [SerializeField]
    private GameObject joueur; // Le joueur qu'on surveille. Quand il tombe dans la bo�te, on le replace

    private float tempsAttente = 0;
    private bool attenteDemarree = false;

    void Update()
    {
        if (attenteDemarree)
            tempsAttente += Time.deltaTime;

        if (tempsAttente > 2)
        {
            tempsAttente = 0;
            attenteDemarree = false;

            // ATTENTION: On utilise deux instances de mouvement diff�rentes pour supporter deux solutions
            // diff�rentes (Input classique + New Input System). Cette probl�matique est peu probable de
            // se produire dans un vrai jeu
            MouvementJoueur mouvement = joueur.GetComponent<MouvementJoueur>();
            MouvementJoueurNewInput mouvementNew = joueur.GetComponent<MouvementJoueurNewInput>();
            if (mouvement != null)
            {
                mouvement.ReplacerJoueur();
            }
            else if (mouvementNew != null)
            {
                mouvementNew.ReplacerJoueur();
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == joueur)
        {
            attenteDemarree = true;
        }
    }
}