using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Classe qui implemente un mouvement avec les touches de direction
 *
 * Auteur: Eric Wenaas
 */
public class MouvementJoueur : MonoBehaviour
{
    // Le niveau de force a appliquer
    [SerializeField] 
    private float niveauForce;

    // Le rigidbody ou on applique la force
    private Rigidbody sphereRigidbody; 

    private Vector3 positionDepart;

    private InputAction mouvement;

    void Start()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
        positionDepart = transform.position;

        mouvement = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        Vector2 mouvementApplique = mouvement.ReadValue<Vector2>();
        Vector3 force = new Vector3(mouvementApplique.x, 0, mouvementApplique.y);
        force *= niveauForce;
        sphereRigidbody.AddForce(force);
    }

    public void ReplacerJoueur()
    {
        transform.position = positionDepart;
        sphereRigidbody.linearVelocity = Vector3.zero;
        sphereRigidbody.angularVelocity = Vector3.zero;
    }
}