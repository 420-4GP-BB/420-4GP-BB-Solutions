using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Classe qui agrandit et diminue une sph�re. Utilise une vitesse qui peut �tre
 * configur�e dans l'inspecteur de Unity.
 *
 * Auteur: �ric Wenaas
 */

public class CroissanceSphereVitesse : MonoBehaviour
{
    private bool _agrandissementActif;   // Pour d�cider si on agrandit ou on diminue la taille de la sph�re
    private Vector3 _vecteurCroissance = new Vector3(0.1f, 0.1f, 0.1f); // Le taux de croissance du vecteur
    
    [SerializeField] private float vitesse;  // La vitesse de croissance/d�croissance de la sph�re

    // Start is called before the first frame update
    void Start()
    {
        _agrandissementActif = true;
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Magnitude initiale: " + transform.localScale.magnitude.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 croissance = _vecteurCroissance * vitesse * Time.deltaTime;

        if (_agrandissementActif)
        {
            transform.localScale += croissance;
        }
        else
        {
            transform.localScale -= croissance;
        }

        if (transform.localScale.magnitude >= 8.0f)
        {
            _agrandissementActif = false;
        }

        if (transform.localScale.magnitude <= 2.0f)
        {
            _agrandissementActif = true;
        }
    }
}
