using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Classe qui fait sorte que l'objet est d�truit s'il entre en contact avec le joueur.
 * Il faut ajouter un Rigidbody � l'objet.
 * 
 * Le joueur doit �gaelement avoir un Collider.
 * 
 * Auteur: �ric Wenaas
 */
public class DetruireObjet : MonoBehaviour
{
    private GameObject _joueur; // Le joueur
    // Start is called before the first frame update
    void Start()
    {
        _joueur = GameObject.Find("Joueur");   // On trouve le joueur, � faire dans Start.
                                               // Ne jamais faire de GameObject.Find dans Update.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _joueur)
        {
            // L'objet se d�truit lui-m�me
            Destroy(gameObject);
        }
    }
}
