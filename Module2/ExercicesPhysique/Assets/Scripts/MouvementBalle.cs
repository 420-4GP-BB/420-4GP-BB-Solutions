using UnityEngine;
using UnityEngine.InputSystem;

// Classe qui permet de deplacer la balle avec des forces
public class MouvementBalle : MonoBehaviour
{
    [SerializeField]
    private float forceBalle = 25f;

    private Vector3 positionInitiale;
    private Rigidbody sphereRigidbody;
    private InputAction mouvementAction;

    void Start()
    {
        // Initialise mes variables privees
        positionInitiale = transform.position;
        sphereRigidbody = GetComponent<Rigidbody>();
        mouvementAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        // Si la balle est en bas de la plateforme
        if (transform.position.y <= -2.0f)
        {
            ReplacerBalle();
        }
    }

    void FixedUpdate()
    {
        Vector2 directionMouvement = mouvementAction.ReadValue<Vector2>();
        Vector3 force = new Vector3(directionMouvement.x, 0, directionMouvement.y);
        force *= forceBalle;
        sphereRigidbody.AddForce(force);
    }

    public void ReplacerBalle()
    {
        // Replace la balle
        sphereRigidbody.position = positionInitiale;

        // Arrete son mouvement lineaire et angulaire
        sphereRigidbody.linearVelocity = Vector3.zero;
        sphereRigidbody.angularVelocity = Vector3.zero;
    }
}