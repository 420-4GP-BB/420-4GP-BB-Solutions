using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe qui montre un écran pendant 5 secondes et retourne au menu
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class EcranFinPartie : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AttendreEtAllerMenu());        
    }

    /// <summary>
    /// Attends 5 secondes et retourne au menu
    /// </summary>
    /// <returns>IEnumerator car c'est une coroutine</returns>
    private IEnumerator AttendreEtAllerMenu()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Menu");
    }

}
