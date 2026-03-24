using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LancerProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _modeleProjectile;
    [SerializeField] private float force;

    private CharacterController characterController;
    private Collider joueurCollider;
    private InputAction click;
    
    private void Start()
    {
        click = InputSystem.actions.FindAction("Click");
        characterController = GetComponent<CharacterController>();
        joueurCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (click.WasPressedThisFrame())
        {
            GameObject projectile = Instantiate(_modeleProjectile);
            projectile.transform.position = transform.position + transform.forward;
            
            var rigidbody = projectile.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.Lerp(transform.forward, Vector3.up, 0.5f) * force, ForceMode.Impulse);

            // Le joueur ne devrait pas entrer en collision avec les projectiles
            var projectileCollider = projectile.GetComponent<Collider>();
            
            Physics.IgnoreCollision(characterController, projectileCollider);
            Physics.IgnoreCollision(joueurCollider, projectileCollider);
        }
    }
}
 
