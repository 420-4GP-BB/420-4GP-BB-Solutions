using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementJoueur : MonoBehaviour
{
    private CharacterController characterController;
    private InputAction move;
    private InputAction jump;
    private InputAction sprint;

    private float velociteY = 0;
    [SerializeField] private float velociteSaut = 5;
    private Vector3 positionDepart;
    private Quaternion rotationDepart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        
        positionDepart = transform.position;
        rotationDepart = transform.rotation;
        
        // Ajout dans l'exercice 6:
        sprint = InputSystem.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        var mouvement = move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(mouvement.x, 0, mouvement.y);
        float magnitudeVitesse = 10;

        // Ajout dans l'exercice 6:
        magnitudeVitesse = ParametresJeu.Instance.Vitesse;
        
        if(sprint.IsPressed())
            magnitudeVitesse *= ParametresJeu.Instance.FacteurCourse;

        Vector3 vitesse = magnitudeVitesse * direction;
        vitesse = transform.TransformDirection(vitesse);

        velociteY += Physics.gravity.y * Time.deltaTime;

        if (jump.IsPressed() && characterController.isGrounded)
            velociteY = velociteSaut;
        else if (characterController.isGrounded)
            velociteY = 0;


        var vitesseTotale = vitesse + new Vector3(0, velociteY, 0);
        characterController.Move(vitesseTotale * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<DetectionFin>())
        {
            characterController.enabled = false;
            transform.position = positionDepart;
            transform.rotation = rotationDepart;
            characterController.enabled = true;
        }
    }
}