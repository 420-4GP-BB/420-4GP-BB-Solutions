using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _dommages;

    void Start()
    {
        StartCoroutine(DetruireProjectile());
    }

    void OnTriggerEnter(Collider other)
    {
        PointsDeVie _pointsDeVie = other.gameObject.GetComponent<PointsDeVie>();
        if (_pointsDeVie != null)
        {
            _pointsDeVie.RetirerPointsDeVie(_dommages);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator DetruireProjectile()
    {
        yield return new WaitForSeconds(3);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
