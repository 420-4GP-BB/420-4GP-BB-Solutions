using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe qui gère la ZoneArrivee. Elle déclenche un événement
 * quand la balle active entre sur la zone
 * 
 * Auteur: Éric Wenaas
 */


public delegate void ZoneAtteinte();

public class ZoneArriveeSujet : MonoBehaviour
{

    public event ZoneAtteinte ZoneAtteinteHandler;

    [SerializeField] private GameObject balleActive; // variable pour la balle active

    // Propriété pour changer la balle active
    public GameObject BalleActive
    {
        set
        {
            balleActive = value;
        }

        get
        {
            return balleActive;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == balleActive)
        {
            // Si la zone n'est pas observée, il ne faut pas déclencher l'événement
            if (ZoneAtteinteHandler != null)
            {
                ZoneAtteinteHandler();
            }
        }
    }
}
