using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HochementTeteV1 : MonoBehaviour
{
    [SerializeField] private float vitesseHochement = 1;
    private Vector3 directionHochement = Vector3.right;

    private bool avant = true;

    // Update is called once per frame
    void Update()
    {
        if (avant)
        {
            transform.position += directionHochement * (vitesseHochement * Time.deltaTime);
        }
        else
        {
            transform.position -= directionHochement * (vitesseHochement * Time.deltaTime);
        }

        if (transform.position.x < -0.2f) avant = true;
        if (transform.position.x > +0.2f) avant = false;
    }
}