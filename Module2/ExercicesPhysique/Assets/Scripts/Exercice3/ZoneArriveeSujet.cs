using System;
using UnityEngine;

// Classe qui declenche un evenement quand la balle entre sur la zone
public class ZoneArriveeSujet : MonoBehaviour
{
    public event Action ZoneAtteinteHandler;

    public GameObject balleActive;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == balleActive)
        {
            // Avertir tout les observateurs que la zone a ete atteinte
            ZoneAtteinteHandler?.Invoke();
        }
    }
}