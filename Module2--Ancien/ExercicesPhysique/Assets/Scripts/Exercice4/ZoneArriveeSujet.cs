using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe qui gère la ZoneArrivee. Elle déclenche un événement
 * quand la balle active entre sur la zone
 *
 * Auteur: Éric Wenaas
 */
public class ZoneArriveeSujet : MonoBehaviour
{
    public event Action ZoneAtteinteHandler;

    [SerializeField] private GameObject balleActive; // variable pour la balle active

    // Propriété pour changer la balle active
    public GameObject BalleActive
    {
        set { balleActive = value; }

        get { return balleActive; }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == balleActive)
        {
            // Avertir les objets intéressés que la zone a été
            // atteinte
            ZoneAtteinteHandler?.Invoke();
        }
    }
}