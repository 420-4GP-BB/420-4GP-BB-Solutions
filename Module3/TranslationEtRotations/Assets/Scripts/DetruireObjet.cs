using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Classe qui fait sorte que l'objet est d�truit s'il entre en contact avec le joueur.
 * 
 * Auteur: �ric Wenaas
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
        // L'objet se d�truit lui-m�me
        Destroy(gameObject);
    }
}
