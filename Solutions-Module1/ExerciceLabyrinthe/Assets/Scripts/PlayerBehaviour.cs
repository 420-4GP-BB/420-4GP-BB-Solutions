using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private float _impulsion;
    [SerializeField] private Rigidbody _rigidbody;
    void FixedUpdate()
    {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 force = new Vector3(horizontal, 0, vertical);
        force *= _impulsion;
        _rigidbody.AddForce(force);
    }
}
