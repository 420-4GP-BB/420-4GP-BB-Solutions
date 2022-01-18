using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CroissanceSphereVitesse : MonoBehaviour
{
    private bool agrandissementActif;   // Pour d�cider si on agrandit ou on diminue la taille de la sph�re
    private Vector3 vecteurCroissance = new Vector3(0.1f, 0.1f, 0.1f); // Le taux de croissance du vecteur
    [SerializeField]
    private float vitesse;  // La vitesse de croissance/d�croissance de la sph�re

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
        Vector3 croissance = vecteurCroissance * vitesse * Time.deltaTime;

        if (agrandissementActif)
        {
            transform.localScale += croissance;
        }
        else
        {
            transform.localScale -= croissance;
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
