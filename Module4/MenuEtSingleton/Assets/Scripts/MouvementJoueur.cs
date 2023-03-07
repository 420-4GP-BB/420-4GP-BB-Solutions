using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de d�placer un joueur avec un CharacterController
/// Le saut et la chute sont impl�ment�s
/// </summary>
public class MouvementJoueur : MonoBehaviour
{
    /// <summary>
    /// Le CharacterController du joueur
    /// </summary>
    private CharacterController characterController;

    /// <summary>
    /// La vitesse du d�placement
    /// </summary>
    private float vitesse;

    /// <summary>
    /// Une simulation de la gravit�
    /// </summary>
    private float gravite;

    /// <summary>
    /// Une simulation de saut vers le haut
    /// </summary>
    private float impulsion;
    
    /// <summary>
    /// Le facteur d'acc�l�ration pour la course
    /// </summary>
    private float facteurCourse;

    /// <summary>
    /// La v�locity est utilis�e pour simuler un effet de gravit�
    /// </summary>
    private Vector3 velocity;

    /// <summary>
    /// La position initiale du joueur
    /// </summary>
    private Vector3 positionInitiale;

    /// <summary>
    /// La rotation initiale du joueur
    /// </summary>
    private Quaternion rotationInitiale;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravite = -9.8f;
        impulsion = 1.0f;
        positionInitiale = transform.position;
        rotationInitiale = transform.rotation;
        velocity = Vector3.zero;
        vitesse = 15.0f;
    }


    /// <summary>
    /// Le code est inspir� de l'exemple trouv� sur https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    /// </summary>
    void Update()
    {
        bool groundedPlayer = characterController.isGrounded;

        vitesse = ParametresUtilisateurs.Instance.Vitesse;
        facteurCourse = ParametresUtilisateurs.Instance.FacteurCourse;

        // Si on est sur le sol, on ne doit pas descendre
        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        // D�placement selon les axes
        float horizontal = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * vitesse * Time.deltaTime;
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
    /// M�thode qui replace le joueur dans sa position et sa rotation initiale
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
