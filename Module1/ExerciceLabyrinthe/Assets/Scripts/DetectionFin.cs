using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Classe qui permet de détecter qu'on a atteint l'objectif.
 * Elle replace le joueur à sa position initiale.
 * 
 * Auteur: Éric Wenaas
 */
public class DetectionFin : MonoBehaviour
{
    [SerializeField] private GameObject joueur; // Le joueur qu'on surveille. Quand il tombe dans la boîte, on le replace
    
    
    private Vector3 _positionDepart; // La position de départ du joueur

    // Start is called before the first frame update
    void Start()
    {
        _positionDepart = joueur.transform.position;
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == joueur)
        {
            // ATTENTION: On utilise deux instances de mouvement différentes pour supporter deux solutions
            // différentes (exerices 5 et 6). Cette problématique est peu probable de se produire dans un jeu.
            MouvementJoueur mouvement = joueur.GetComponent<MouvementJoueur>();
            MouvementJoueurNewInput mouvementNew = joueur.GetComponent<MouvementJoueurNewInput>();
            if (mouvement != null)
            {
                StartCoroutine(ReplacerJoueur(mouvement));
            }
            else if (mouvementNew != null)
            {
                StartCoroutine(ReplacerJoueur(mouvementNew));
            }
        }
    }


    /**
     * Coroutine qui attend et replace le joueur à sa position intiale
     */
    private IEnumerator ReplacerJoueur(MouvementJoueur mouvement)
    {
        // On attend deux secondes
        yield return new WaitForSeconds(2.0f);

        // On replace le joueur.
        mouvement.ReplacerJoueur();
    }

    // Copie pour supporter l'exercice 6 qui utilise une autre classe
    // pour le mouvement.
    private IEnumerator ReplacerJoueur(MouvementJoueurNewInput mouvement)
    {
        // On attend deux secondes
        yield return new WaitForSeconds(2.0f);

        // On replace le joueur.
        mouvement.ReplacerJoueur();
    }
}
