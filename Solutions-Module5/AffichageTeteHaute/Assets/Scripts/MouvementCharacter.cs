using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ObjectifAtteint();
public delegate void PartiePerdue();

public class MouvementCharacter : MonoBehaviour
{
    public event ObjectifAtteint ObjectifAtteintHandler;
    public event PartiePerdue PartiePerdueHandler;

    [SerializeField] private float vitesse;
    [SerializeField] private GameObject plancherBoite;

    private float gravity = 9.8f;
    private CharacterController _controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        float vitesseReelle = vitesse;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vitesseReelle *= 1.5f;
        }

        float horizontal = Input.GetAxis("Horizontal") * vitesseReelle;
        float vertical = Input.GetAxis("Vertical") * vitesseReelle;


        float y = 0;
        if (_controller.isGrounded)
        {
            // Peut sauter
            if (Input.GetButton("Jump"))
            {
                y = 20 * gravity;
            }
        } 
        else
        {
            y = gravity * -1;
        }


        Vector3 deplacement = new Vector3(horizontal, y, vertical) * Time.fixedDeltaTime;
        deplacement = transform.TransformDirection(deplacement);
        _controller.Move(deplacement);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject == plancherBoite)
        {
            ObjectifAtteintHandler();
        } 
        else if (hit.gameObject.tag == "Ennemi")
        {
            PartiePerdueHandler();
        }
    }
}
