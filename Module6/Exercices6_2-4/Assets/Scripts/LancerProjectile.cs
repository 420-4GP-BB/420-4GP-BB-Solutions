using UnityEngine;
using UnityEngine.InputSystem;

public class LancerProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabProjectile;

    [SerializeField]
    private float force;

    private CharacterController characterController;
    private Collider joueurCollider;
    
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        joueurCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject projectile = Instantiate(prefabProjectile);
            projectile.transform.position = transform.position + transform.forward;

            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.AddForce(Vector3.Lerp(transform.forward, Vector3.up, 0.5f) * force, ForceMode.Impulse);

            // Le joueur ne devrait pas entrer en collision avec les projectiles
            Collider projectileCollider = projectile.GetComponent<Collider>();
            
            Physics.IgnoreCollision(characterController, projectileCollider);
            Physics.IgnoreCollision(joueurCollider, projectileCollider);
        }
    }
}
 
