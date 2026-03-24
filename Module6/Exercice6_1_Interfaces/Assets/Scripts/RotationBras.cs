using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBras : MonoBehaviour
{
    [SerializeField] private float vitesseRotation = 180;

    // Update is called once per frame
    void Update()
    {
        // Rotation autour d'un axe, avec comme centre le pivot de l'objet
        transform.Rotate(new Vector3(1, 0, 0), Time.deltaTime * vitesseRotation);
    }
}