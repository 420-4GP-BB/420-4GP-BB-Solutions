using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{

    [SerializeField] private float forceProjection;

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Projection");
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * forceProjection);
    }
}
