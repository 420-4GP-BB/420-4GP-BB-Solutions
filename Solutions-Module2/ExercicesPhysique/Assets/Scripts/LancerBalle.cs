using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public delegate void LancerReussi();
public class LancerBalle : MonoBehaviour
{
    public event LancerReussi LancerReussiHandler;

    [SerializeField] private float incrementForce;

    private Rigidbody rb;
    
    private float forceAccumulee;
    
    private bool enMouvement;
    
    private bool lancerRequis;

    private Vector3 positionDepart;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        positionDepart = transform.position;
        enMouvement = false;
        lancerRequis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && ! enMouvement)
        {
            forceAccumulee += incrementForce * Time.deltaTime;
            Debug.Log("Force accumulée: " + forceAccumulee.ToString());
        } else if (Input.GetKeyUp(KeyCode.Space) && ! enMouvement)
        {
            lancerRequis = true;
        }

        if (transform.position.y < -25)
        {
            transform.position = positionDepart;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            LancerReussiHandler();
        }

        if (rb.velocity == Vector3.zero)
        {
            enMouvement = false;
        }
    }

    private void FixedUpdate()
    {
        if (lancerRequis)
        {
            rb.AddForce(Vector3.forward * forceAccumulee);
            lancerRequis = false;
            enMouvement = true;
            forceAccumulee = 0;
        }
    }
}
