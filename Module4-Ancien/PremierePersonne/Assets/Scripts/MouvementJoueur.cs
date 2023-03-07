using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de déplacer un joueur avec un CharacterController
/// Le saut et la chute sont implémentés
/// </summary>
public class MouvementJoueur : MonoBehaviour
{
    /// <summary>
    /// La vitesse du personnage
    /// </summary>
    [SerializeField] private float vitesse;
    /// <summary>
    /// Le CharacterController du joueur
    /// </summary>
    private CharacterController characterController;
    /// <summary>
    /// Le facteur de multiplication pour la course
    /// </summary>
    private float augmentationCourse;
    /// <summary>
    /// Une simulation de la gravité
    /// </summary>
    private float gravite;
    /// <summary>
    /// Une simulation de saut vers le haut
    /// </summary>
    private float impulsion;
    /// <summary>
    /// La position initiale du joueur
    /// </summary>
    private Vector3 positionInitiale;
    /// <summary>
    /// La rotation initiale du joueur
    /// </summary>
    private Quaternion rotationInitiale;
    /// <summary>
    /// Le facteur d'accélération pour la course
    /// </summary>
    private float facteurCourse;
    /// <summary>
    /// La vélocity est utilisée pour simuler un effet de gravité
    /// </summary>
    private Vector3 velocity;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        augmentationCourse = 1.5f;
        gravite = -9.8f;
        impulsion = 1.0f;
        positionInitiale = transform.position;
        rotationInitiale = transform.rotation;
    }

    void Update()
    {
        bool groundedPlayer = characterController.isGrounded;
        float horizontal = 0.0f;
        float vertical = 0.0f;

        horizontal = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * vitesse * Time.deltaTime;


        // Si on est sur le sol, on ne doit plus descendre
        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);
        
        characterController.Move(direction);

        if (velocity.y == 0 && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(impulsion * -3.0f * gravite);
        }

        velocity.y += gravite * Time.deltaTime;
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
