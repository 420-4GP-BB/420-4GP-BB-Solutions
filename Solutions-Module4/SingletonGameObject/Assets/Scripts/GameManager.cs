using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Illustration du singleton dans un contexte de Unity
/// 
/// Exemple bas� sur le chapitre 4 de Game Development Patterns with Unity 2021, David Baron, Packt, 2021.
/// 
/// 
/// Auteur: �ric Wenaas
/// </summary>
public class GameManager : MonoBehaviour 
{
    /// <summary>
    /// L'instance statique du singleton
    /// </summary>
    private static GameManager _instance;

    /// <summary>
    /// Propri�t� qui retourne l'objet du singleton
    /// </summary>
    /// <summary>
    /// La vitesse quand le joueur se d�place normalement
    /// </summary>
    private int vitesse = 15;

    /// <summary>
    /// Le facteur de course.
    /// </summary>
    private float facteurCourse = 1.5f;

    public static GameManager Instance
    {
        get
        {
            // cherche si l'instance existe
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            // si on ne l'a pas trouv�, on la cr�e
            if (_instance == null)
            {
                GameObject obj = new GameObject("Game Manager");
                _instance = obj.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // On v�rifie si c'est la premi�re fois que la variable statique est affect�e
        // et on s'assure que l'objet ne sera pas d�truit
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);     // La source cite plus haut fait Destroy(gameObject) ce qui semble suspect.
        }
    }

    /// <summary>
    /// La vitesse de base du joueur
    /// </summary>
    public int Vitesse
    {
        set { vitesse = value; }
        get { return vitesse; }
    }

    /// <summary>
    /// Multiplicateur de la vitesse quand le joueur cours
    /// </summary>
    public float FacteurCourse
    {
        set { facteurCourse = value; }
        get { return facteurCourse; }
    }

}
