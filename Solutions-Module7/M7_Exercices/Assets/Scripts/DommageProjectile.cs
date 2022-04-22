using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe attaché à un projectile qui cause des dommages à un objet ayant des points de vie
/// 
/// Auteur: Eric Wenaas
/// </summary>
public class DommageProjectile : MonoBehaviour
{
    [SerializeField] private int quantiteDegat;

    public void Construct(int degat)
    {
        quantiteDegat = degat;
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject objetTouche = collision.gameObject;
        PointDeVie pointDeVie = objetTouche.GetComponent<PointDeVie>();
        if (pointDeVie != null)
        {
            pointDeVie.RetirerPointDeVie(quantiteDegat);
        }
        Destroy(gameObject);
    }
}
