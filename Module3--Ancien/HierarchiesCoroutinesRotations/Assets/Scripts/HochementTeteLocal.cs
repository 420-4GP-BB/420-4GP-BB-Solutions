using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HochementTeteLocal : MonoBehaviour
{
    [SerializeField] private float vitesseHochement = 1;
    private Vector3 directionHochement = Vector3.right;

    private bool avant = true;

    // Update is called once per frame
    void Update()
    {
        if (avant)
        {
            transform.localPosition += directionHochement * (vitesseHochement * Time.deltaTime);
        }
        else
        {
            transform.localPosition -= directionHochement * (vitesseHochement * Time.deltaTime);
        }

        if (transform.localPosition.x < -0.2f) avant = true;
        if (transform.localPosition.x > +0.2f) avant = false;
    }
}