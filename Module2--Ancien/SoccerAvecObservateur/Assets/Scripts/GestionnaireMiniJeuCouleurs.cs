using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireMiniJeuCouleurs : MonoBehaviour
{
    [SerializeField] Balle _balle;
    [SerializeField] CouleurHasard _couleurHasard;

    private int points = 0;

    void Start()
    {
        _balle.OnBalleDansFilet += VerifierSiPoint;
    }

    private void VerifierSiPoint(Balle balle, Collider other)
    {
        string nomParent = other.transform.parent.name;
        if (nomParent == "ButRouge" && _couleurHasard.NumeroCouleur == 0)
        {
            points++;
        }
        else if (nomParent == "ButVert" && _couleurHasard.NumeroCouleur == 1)
        {
            points++;
        }
        else if (nomParent == "ButBleu" && _couleurHasard.NumeroCouleur == 2)
        {
            points++;
        }
        else
        {
            Debug.Log("Mauvais filet!");
            _balle.RemiseAZero();
            return;
        }

        Debug.Log("Points: " + points);
        _balle.RemiseAZero();
    }
}