using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesRigidbody : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        transform.Rotate(0, horizontal, 0);
        _rb.AddForce(transform.forward * (vertical * speed));
    }
}
