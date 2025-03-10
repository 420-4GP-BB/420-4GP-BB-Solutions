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

    private GestionnaireJeu gestionnaireJeu;

    public void Start()
    {
        gestionnaireJeu = GestionnaireJeu.Instance;
        saisieVitesse.text = gestionnaireJeu.Vitesse.ToString();
        saisieAcceleration.text = gestionnaireJeu.FacteurAcceleration.ToString();
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
            gestionnaireJeu.Vitesse = float.Parse(saisieVitesse.text);
        }
    }

    public void ChangerAcceleration()
    {
        if (saisieAcceleration.text != null)
        {
            gestionnaireJeu.FacteurAcceleration = float.Parse(saisieAcceleration.text);
        }
    }
}
