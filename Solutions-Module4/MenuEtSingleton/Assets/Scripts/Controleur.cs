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
    /// <summary>
    /// Le champ de saisie de vitesse
    /// </summary>
    [SerializeField] private TMP_InputField saisieVitesse;

    /// <summary>
    /// Le champ de saisie de l'acceleration
    /// </summary>
    [SerializeField] private TMP_InputField saisieAcceleration;

    public void Start()
    {
        saisieVitesse.text = ParametresUtilisateurs.Instance.Vitesse.ToString();
        saisieAcceleration.text = ParametresUtilisateurs.Instance.FacteurCourse.ToString();
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
        SceneManager.LoadScene("Exercices5_6");
    }

    public void ChangerVitesse()
    {
        ParametresUtilisateurs.Instance.Vitesse = Int32.Parse(saisieVitesse.text);
    }

    public void ChangerAcceleration()
    {
        ParametresUtilisateurs.Instance.FacteurCourse = float.Parse(saisieAcceleration.text);
    }
}
