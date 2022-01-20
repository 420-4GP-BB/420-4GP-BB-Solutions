using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Cette classe sert à projeter la balle quand elle arrive dans la zone.
 * 
 * Auteur : Éric Wenaas
 * 
 */ 
public class Projection : MonoBehaviour
{
    [SerializeField] private float forceProjection;  // La force de projection
    [SerializeField] private Vector3 directionProjection; // la direction de la projection

    private void OnTriggerEnter(Collider other)
    {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * forceProjection);
    }
}
