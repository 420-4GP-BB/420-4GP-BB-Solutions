using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de déplacer un joueur avec un CharacterController
/// Le saut et la chute sont implémentés
/// </summary>
public class MouvementJoueur : MonoBehaviour
{
    private CharacterController characterController;
    private float vitesse;
    private float gravite;
    private float impulsion;
    private Vector3 velocity;
    private Vector3 positionInitiale;
    private Quaternion rotationInitiale;
    private GameManager gameManager;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravite = -9.8f;
        impulsion = 1.0f;
        positionInitiale = transform.position;
        rotationInitiale = transform.rotation;
        velocity = Vector3.zero;
        vitesse = 15.0f;
        gameManager = GameManager.Instance;
        vitesse = gameManager.Vitesse;
    }


    /// <summary>
    /// Le code est inspiré de l'exemple trouvé sur https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    /// </summary>
    void Update()
    {
        bool groundedPlayer = characterController.isGrounded;
        

        // Si on est sur le sol, on ne doit pas descendre
        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        // Déplacement selon les axes

        float vitesseApplicable = vitesse;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vitesseApplicable *= gameManager.FacteurAcceleration;
        }
        float horizontal = Input.GetAxis("Horizontal") * vitesseApplicable * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * vitesseApplicable * Time.deltaTime;


        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);
        characterController.Move(direction);

        if (velocity.y == 0 && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(impulsion * -3.0f * gravite);
        }

        velocity.y += gravite* Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    /// <summary>
    /// Méthode qui replace le joueur dans sa position et sa rotation initiale
    /// </summary>
    internal void ReplacerJoueur()
    {
        characterController.enabled = false;
        transform.position = positionInitiale;
        transform.rotation = rotationInitiale;
        characterController.enabled = true;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject == GameObject.Find("Objectif"))
        {
            ReplacerJoueur();
        }
    }
}
