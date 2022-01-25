using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Classe qui fait grandir et diminuer une sphère
 *
 * Auteur: Éric Wenaas
 */ 

public class CroissanceSphere : MonoBehaviour
{
    private bool _agrandissementActif;   // Pour décider si on agrandit ou on diminue la taille de la sphère
    private Vector3 _vecteurCroissance = new Vector3(0.1f, 0.1f, 0.1f); // Le taux de croissance du vecteur
                                                                       // Si on change ces valeurs, on change la vitesse d'acroissement.
                                                                       // Sera fait autrement dans l'exercice 2

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
        if (_agrandissementActif)
        {
            transform.localScale += _vecteurCroissance;
        }
        else
        {
            transform.localScale -= _vecteurCroissance;
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
