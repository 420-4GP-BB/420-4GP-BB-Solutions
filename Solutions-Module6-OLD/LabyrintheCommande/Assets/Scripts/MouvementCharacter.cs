using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ObjectifAtteint();
// public delegate void PartiePerdue();

public class MouvementCharacter : MonoBehaviour
{
    public event ObjectifAtteint ObjectifAtteintHandler;
    // public event PartiePerdue PartiePerdueHandler;

    [SerializeField] private float vitesse;
    [SerializeField] private GameObject plancherBoite;

    private float gravity = 9.8f;
    private CharacterController _controller;
    private bool firstTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        firstTime = false;
    }

    public void Sauter()
    {
        float x = 0;
        float z = 0;
        float y = 5;
        if (_controller.isGrounded)
        {
            Vector3 deplacement = new Vector3(x, y, z);
            deplacement = transform.TransformDirection(deplacement);
            _controller.Move(deplacement);
        }
    }
    
    private void Update()
    {
        float vitesseReelle = vitesse;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vitesseReelle *= 1.5f;
        }

        float horizontal = Input.GetAxis("Horizontal") * vitesseReelle;
        float vertical = Input.GetAxis("Vertical") * vitesseReelle;
        float y = 0;
        if (! _controller.isGrounded)
        {
            y = gravity * -1;
        }
        Vector3 deplacement = new Vector3(horizontal, y, vertical) * Time.deltaTime;
        deplacement = transform.TransformDirection(deplacement);
        _controller.Move(deplacement);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject == plancherBoite)
        {
            if (!firstTime)
            {
                ObjectifAtteintHandler();
                firstTime = true;
            }
        } 
        else if (hit.gameObject.tag == "Ennemi")
        {
//            PartiePerdueHandler();
        }
    }
}
