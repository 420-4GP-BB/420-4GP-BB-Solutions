using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Classe qui fait sorte que l'objet est détruit s'il entre en contact avec le joueur.
 * Il faut ajouter un Rigidbody à l'objet.
 * 
 * Le joueur doit égaelement avoir un Collider.
 * 
 * Auteur: Éric Wenaas
 */
public class DetruireObjet : MonoBehaviour
{
    private GameObject _joueur; // Le joueur
    // Start is called before the first frame update
    void Start()
    {
        _joueur = GameObject.Find("Joueur");   // On trouve le joueur, à faire dans Start.
                                               // Ne jamais faire de GameObject.Find dans Update.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _joueur)
        {
            // L'objet se détruit lui-même
            Destroy(gameObject);
        }
    }
}
