using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de déplacer un joueur avec un CharacterController
/// Le saut et la chute sont implémentés
/// </summary>
public class MouvementJoueurSaut : MonoBehaviour
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

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        augmentationCourse = 1.5f;
        gravite = -9.8f;
        impulsion = 250.0f;
        positionInitiale = transform.position;
        rotationInitiale = transform.rotation;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * vitesse;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * vitesse;
        float y = 0.0f;
        
        // On regarde si on court
        if (Input.GetKey(KeyCode.LeftShift))
        {
            x *= augmentationCourse;
            z *= augmentationCourse;
        }

        // On regarde s'il faut sauter   
        if (characterController.isGrounded &&  Input.GetButton("Jump"))
        {
            y += impulsion * Time.deltaTime;
        }

        // Si on est pas sur le sol, on descend
        if (! characterController.isGrounded)
        {
            y += gravite * Time.deltaTime;
        }

        // On déplace à la fin
        Vector3 translation = new Vector3(x, y, z);
        translation = transform.TransformDirection(translation);
        characterController.Move(translation);
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
}
