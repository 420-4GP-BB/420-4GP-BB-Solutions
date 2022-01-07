using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDeVie : MonoBehaviour
{

    [SerializeField] int pointsDeVieMax;

    private int _pointsActuels;
    // Start is called before the first frame update
    void Start()
    {
        _pointsActuels = pointsDeVieMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Projectile")
        {
            _pointsActuels--;

            if (_pointsActuels == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Color couleur = GetComponent<Renderer>().material.color;
                couleur = new Color(couleur.r / 2, couleur.g / 2, couleur.b / 2);
                GetComponent<Renderer>().material.color = couleur;
            }
        }
    }
}
