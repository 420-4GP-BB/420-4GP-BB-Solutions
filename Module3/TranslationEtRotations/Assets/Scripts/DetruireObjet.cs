using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Classe qui fait sorte que l'objet est détruit s'il entre en contact avec le joueur.
 * 
 * Auteur: Éric Wenaas
 */
public class DetruireObjet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // L'objet se détruit lui-même
        Destroy(gameObject);
    }
}
