using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Classe qui permet de gérer des points de vie pour les champignons
/// 
/// Auteur: Eric Wenaas
/// </summary>

public delegate void AtteintZero(GameObject obj);

public class PointDeVie : MonoBehaviour
{
    public event AtteintZero AtteintZeroHandler;

    /// <summary>
    /// Le nombre de point de vie maximum
    /// </summary>
    [SerializeField] private int pointsVieMax;
    public int NombrePointsVie
    {
        private set;
        get;
    }

    /// <summary>
    /// Pour contourner le problème des champs sérialisés lors des tests unitaires
    /// 
    /// </summary>
    /// <param name="pointsMax">Les points de vie maximum</param>
    public void Construct(int pointsMax)
    {
        pointsVieMax = pointsMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        NombrePointsVie = pointsVieMax;
    }


    /// <summary>
    /// Permet de retirer un montant de points de vie
    /// </summary>
    /// <param name="nombre">Le nombre de points de vie à enlever</param>
    public void RetirerPointDeVie(int nombre)
    {
        NombrePointsVie -= nombre;
        if (NombrePointsVie <= 0 && AtteintZeroHandler != null)
        {
            AtteintZeroHandler(gameObject);
        }
    }
}
