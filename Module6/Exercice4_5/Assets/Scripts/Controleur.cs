using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Controleur : MonoBehaviour
{

    [SerializeField] private TMP_InputField saisieVitesse;
    [SerializeField] private TMP_InputField saisieAcceleration;

    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
        saisieVitesse.text = gameManager.Vitesse.ToString();
        saisieAcceleration.text = gameManager.FacteurAcceleration.ToString();
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
        ChangerVitesse();
        ChangerAcceleration();
        SceneManager.LoadScene("Labyrinthe");
    }

    public void ChangerVitesse()
    {
        if (saisieVitesse.text != null)
        {
            gameManager.Vitesse = float.Parse(saisieVitesse.text);
        }
    }

    public void ChangerAcceleration()
    {
        if (saisieAcceleration.text != null)
        {
            gameManager.FacteurAcceleration = float.Parse(saisieAcceleration.text);
        }
    }
}
