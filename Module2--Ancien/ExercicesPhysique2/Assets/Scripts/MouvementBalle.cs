using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Cette classe permet de deplacer la balle avec des forces
 *
 * Auteur : Eric Wenaas
 */
public class MouvementBalle : MonoBehaviour
{
    // La force de la balle
    [SerializeField]
    private float forceBalle;

    // Le Rigidbody de la balle
    private Rigidbody sphereRigidbody;

    // La position initiale de la balle
    public Vector3 positionInitiale;

    private InputAction mouvement;

    void Start()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
        positionInitiale = transform.position;

        mouvement = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        // Pour l exercice 3
        if (transform.localPosition.y <= -2.0f)
        {
            ReplacerBalle();
        }
    }

    void FixedUpdate()
    {
        Vector2 mouvementApplique = mouvement.ReadValue<Vector2>();
        Vector3 force = new Vector3(mouvementApplique.x, 0, mouvementApplique.y);
        force *= forceBalle;
        sphereRigidbody.AddForce(force);
    }

    /**
     * Methode qui replace la balle au bon endroit
     *
     * Utilisee dans l exercice 3
     */
    public void ReplacerBalle()
    {
        sphereRigidbody.position = positionInitiale;
        sphereRigidbody.linearVelocity = Vector3.zero;
        sphereRigidbody.angularVelocity = Vector3.zero;
    }
}