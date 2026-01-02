using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{
    [SerializeField] Balle _balle;
    
    private int pointsBleu = 0;
    private int pointsRouge = 0;
    
    void Start()
    {
        _balle.OnBalleDansFilet += PointCompte;
    }

    private void PointCompte(Balle balle, Collider other)
    {
        string nomParent = other.transform.parent.name;
        if (nomParent == "ButRouge")
        {
            pointsBleu++;
        }
        else if (nomParent == "ButBleu")
        {
            pointsRouge++;
        }

        Debug.Log("POINT! Bleus: " + pointsBleu + " || Rouges: " + pointsRouge);
        _balle.RemiseAZero();
    }
}
