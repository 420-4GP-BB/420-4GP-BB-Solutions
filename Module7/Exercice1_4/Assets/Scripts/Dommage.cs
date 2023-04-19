using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Dommage : MonoBehaviour
{
    [SerializeField] private int dommage;

    private void OnTriggerEnter(Collider collision)
    {
        PointsVie pointDeVie = collision.GetComponent<PointsVie>();
        if (pointDeVie != null)
        {
            pointDeVie.RetirerPointsVie(dommage);
        }
        Destroy(gameObject);
    }

#if UNITY_EDITOR
    public void SetDommage(int dommage)
    {
        this.dommage = dommage;
    }

#endif
}
