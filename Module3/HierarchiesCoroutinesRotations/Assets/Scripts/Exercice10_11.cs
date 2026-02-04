using UnityEngine;

// Script qui rotate les bras autours de leurs pivots
public class Exercice10_11 : MonoBehaviour
{
    [SerializeField] 
    private float vitesseRotation = 200f;

    void Update()
    {
        float rotationAppliquee = vitesseRotation * Time.deltaTime;

        // Rotation autour de l axe des Z, avec comme centre le pivot de l objet
        transform.Rotate(new Vector3(rotationAppliquee, 0f, 0f));
    }
}