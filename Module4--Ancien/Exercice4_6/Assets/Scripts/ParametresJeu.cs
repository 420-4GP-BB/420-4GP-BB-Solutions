using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Les param�tres sont impl�ment�s avec un singleton
/// 
/// Auteur: �ric Wenaas, Nicolas Hurtubise
/// </summary>
public class ParametresJeu
{
    /// <summary>
    /// L'instance statique du singleton
    /// </summary>
    public static ParametresJeu Instance { get; } = new ParametresJeu();

    /// <summary>
    /// La vitesse du personnage
    /// </summary>
    public int Vitesse { set; get; } = 15;

    /// <summary>
    /// Le facteur d'acc�l�ration
    /// </summary>
    public float FacteurCourse { set; get; } = 1.5f;

    /// <summary>
    /// C'est un singleton. Le constructeur est priv�
    /// </summary>
    private ParametresJeu()
    {
    }
}