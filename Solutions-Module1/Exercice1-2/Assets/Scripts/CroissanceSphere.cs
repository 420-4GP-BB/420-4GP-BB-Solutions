using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CroissanceSphere : MonoBehaviour
{
    private bool agrandissementActif;   // Pour décider si on agrandit ou on diminue la taille de la sphère
    private Vector3 vecteurCroissance = new Vector3(0.1f, 0.1f, 0.1f); // Le taux de croissance du vecteur
                                                                       // Si on change ces valeurs, on change la vitesse d'acroissement.
                                                                       // Sera fait autrement dans l'exercice 2

    // Start is called before the first frame update
    void Start()
    {
        agrandissementActif = true;
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Magnitude initiale: " + transform.localScale.magnitude.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (agrandissementActif)
        {
            transform.localScale += vecteurCroissance;
        }
        else
        {
            transform.localScale -= vecteurCroissance;
        }

        if (transform.localScale.magnitude >= 8.0f)
        {
            agrandissementActif = false;
        }

        if (transform.localScale.magnitude <= 2.0f)
        {
            agrandissementActif = true;
        }
    }
}
