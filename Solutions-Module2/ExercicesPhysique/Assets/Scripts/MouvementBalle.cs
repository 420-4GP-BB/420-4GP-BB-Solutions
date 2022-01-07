using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBalle : MonoBehaviour
{

    [SerializeField] private float impulsion;

    private Vector3  positionDepart;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        positionDepart = transform.localPosition;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        // Seulement utile pour le numéro 3.
        if (transform.localPosition.y < -2)
        {
            transform.localPosition = positionDepart;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    
    void FixedUpdate()
    { 
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 force = new Vector3(horizontal, 0, vertical);
        rb.AddForce(force * impulsion);
    }
}
