using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe qui replace le joueur à sa position initiale quand il entre dans la zone
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class ZoneArrivee : MonoBehaviour
{
    /// <summary>
    /// Le joueur qu'on doit replacer
    /// </summary>
    private GameObject joueur;

    void Start()
    {
        joueur = GameObject.Find("Joueur");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == joueur)
        {
            SceneManager.LoadScene("Victoire");
        }
    }
}
