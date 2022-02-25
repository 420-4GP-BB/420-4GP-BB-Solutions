using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de déplacer un joueur avec un CharacterController
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

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        augmentationCourse = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * vitesse;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * vitesse;
        
        // On regarde si on court
        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontal *= augmentationCourse;
            vertical *= augmentationCourse;
        }

        // Déplacement du personnage
        Vector3 translation = new Vector3(horizontal, 0, vertical);
        translation = transform.TransformDirection(translation);
        characterController. Move(translation);
    }
}
