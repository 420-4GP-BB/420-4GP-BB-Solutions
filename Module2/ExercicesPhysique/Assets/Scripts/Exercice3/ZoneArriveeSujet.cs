using System;
using UnityEngine;

/**
 * Classe qui gere la ZoneArrivee. Elle declenche un evenement
 * quand la balle active entre sur la zone
 *
 * Auteur: Eric Wenaas
 */
public class ZoneArriveeSujet : MonoBehaviour
{
    public event Action ZoneAtteinteHandler;

    // Variable pour la balle active
    public GameObject balleActive;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == balleActive)
        {
            // Avertir les objets interesses que la zone a ete atteinte
            ZoneAtteinteHandler?.Invoke();
        }
    }
}