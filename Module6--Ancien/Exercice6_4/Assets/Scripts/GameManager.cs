using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Illustration du singleton dans un contexte de Unity
/// 
/// Exemple basé sur le chapitre 4 de Game Development Patterns with Unity 2021, David Baron, Packt, 2021.
/// 
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private float _vitesse;
    [SerializeField] private float _facteurAcceleration;

    private static GameManager _instance;

    public float Vitesse
    {
        get { return _vitesse; }
        set { _vitesse = value; }
    }

    [SerializeField]
    public float FacteurAcceleration
    {
        get { return _facteurAcceleration; }
        set { _facteurAcceleration = value; }
    }

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        // On vérifie si c'est la première fois que la variable statique est affectée
        // et on s'assure que l'objet ne sera pas détruit lors du chargement d'une autre scène
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);     // La source citée plus haut fait Destroy(gameObject) ce qui semble suspect.
        }
    }
}
