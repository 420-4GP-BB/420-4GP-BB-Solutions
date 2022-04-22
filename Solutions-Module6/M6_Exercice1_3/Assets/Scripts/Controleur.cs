using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

/// <summary>
/// Controleur de l'interface du menu
/// </summary>
public class Controleur : MonoBehaviour
{
    /// <summary>
    /// Le champ de saisie de vitesse
    /// </summary>
    [SerializeField] private TMP_InputField saisieVitesse;

    /// <summary>
    /// Le champ de saisie de l'acceleration
    /// </summary>
    [SerializeField] private TMP_InputField saisieAcceleration;

    /// <summary>
    /// Le Game Manager est un singleton
    /// </summary>
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
        saisieVitesse.text = gameManager.Vitesse.ToString();
        saisieAcceleration.text = gameManager.FacteurCourse.ToString();
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quitter()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ChargerJeu()
    {
        SceneManager.LoadScene("Labyrinthe");
    }

    public void ChangerVitesse()
    {
        gameManager.Vitesse = Int32.Parse(saisieVitesse.text);
    }

    public void ChangerAcceleration()
    {
        gameManager.FacteurCourse = float.Parse(saisieAcceleration.text);
    }
}
