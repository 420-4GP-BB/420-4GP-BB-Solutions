using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _dommages;

    void Start()
    {
        // Détruire un objet après un certain temps est tellement commun dans les jeux
        // qu'une seconde version de la méthode Destroy() fait pile ça
        //
        // Notez qu'on aurait pu se faire une coroutine équivalente ici,
        // qui fait un simple:
        //
        //     yield return new WaitForSeconds(3);
        //     Destroy(gameObject);
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision other)
    {
        PointsDeVie _pointsDeVie = other.gameObject.GetComponent<PointsDeVie>();
        if (_pointsDeVie != null)
        {
            _pointsDeVie.RetirerPointsDeVie(_dommages);
        }
        
        // XXX: Compatibilité avec la version du script pour l'exercice 4
        // En vrai, en terminant l'exercice 4 vous devriez avoir un seul script PointDeVies
        PointsDeVieV2 _pointsDeVieV2 = other.gameObject.GetComponent<PointsDeVieV2>();
        if (_pointsDeVieV2 != null)
        {
            _pointsDeVieV2.RetirerPointsDeVie(_dommages);
        }
        
        Destroy(gameObject);
    }
}
