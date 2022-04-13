using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe qui vérifie si le champignon entre en contact avec le joueur.
/// Si c'est le cas, le joueur perd la partie.
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class ContactJoueur : MonoBehaviour
{
    /// <summary>
    /// Le joueur
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
            SceneManager.LoadScene("Defaite");
        }
    }
}
