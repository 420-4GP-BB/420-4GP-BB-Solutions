using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Les param�tres sont impl�ment�s avec un singleton
/// 
/// Auteur: �ric Wenaas
/// </summary>
public class ParametresUtilisateurs
{
    /// <summary>
    /// L'instance statique du singleton
    /// </summary>
    private static ParametresUtilisateurs _instance = new ParametresUtilisateurs();

    /// <summary>
    /// Propri�t� pour obtenir l'instance
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
    /// Le facteur d'acc�l�ration
    /// </summary>
    public float FacteurAcceleration
    {
        set;
        get;
    }

    /// <summary>
    /// C'est un singleton. Le constructeur est priv�
    /// </summary>
    private ParametresUtilisateurs()
    {
        Vitesse = 15;
        FacteurAcceleration = 1.5f;
    }
}
