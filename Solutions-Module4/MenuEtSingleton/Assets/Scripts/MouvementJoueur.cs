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
    /// Le CharacterController du joueur
    /// </summary>
    private CharacterController characterController;

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
        gravite = -9.8f;
        impulsion = 250.0f;
        positionInitiale = transform.position;
        rotationInitiale = transform.rotation;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * ParametresUtilisateurs.Instance.Vitesse;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * ParametresUtilisateurs.Instance.Vitesse;
        float y = 0.0f;
        
        // On regarde si on court
        if (Input.GetKey(KeyCode.LeftShift))
        {
            x *= ParametresUtilisateurs.Instance.FacteurAcceleration;
            z *= ParametresUtilisateurs.Instance.FacteurAcceleration;
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
