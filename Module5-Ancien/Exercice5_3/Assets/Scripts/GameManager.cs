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
        // On v�rifie si c'est la premi�re fois que la variable statique est affect�e
        // et on s'assure que l'objet ne sera pas d�truit lors du chargement d'une autre sc�ne
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);     // La source cit�e plus haut fait Destroy(gameObject) ce qui semble suspect.
        }
    }
}
