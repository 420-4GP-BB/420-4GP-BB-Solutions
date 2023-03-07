using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Les paramètres sont implémentés avec un singleton
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class ParametresUtilisateurs
{
    /// <summary>
    /// L'instance statique du singleton
    /// </summary>
    private static ParametresUtilisateurs _instance = new ParametresUtilisateurs();

    /// <summary>
    /// Propriété pour obtenir l'instance
    /// </summary>
    public static ParametresUtilisateurs Instance
    {
        get { return _instance;}
    }

    /// <summary>
    /// La vitesse du personnage
    /// </summary>
    public int Vitesse
    {
        set;
        get;
    }

    /// <summary>
    /// Le facteur d'accélération
    /// </summary>
    public float FacteurCourse
    {
        set;
        get;
    }

    /// <summary>
    /// C'est un singleton. Le constructeur est privé
    /// </summary>
    private ParametresUtilisateurs()
    {
        Vitesse = 15;
        FacteurCourse = 1.5f;
    }
}
