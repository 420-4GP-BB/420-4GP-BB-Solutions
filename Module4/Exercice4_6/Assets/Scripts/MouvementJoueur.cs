using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    [SerializeField] private float _vitesse;
    [SerializeField] private float _forceSaut;
    private CharacterController _characterController;
    private float _augmentationCourse;
    private Vector3 _positionInitiale;
    private Quaternion _rotationInitiale;
    private Vector3 _velocity;
    [SerializeField] private GameObject _objectif;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _positionInitiale = transform.position;
        _rotationInitiale = transform.rotation;
        _vitesse = ParametresUtilisateurs.Instance.Vitesse;
        _augmentationCourse = ParametresUtilisateurs.Instance.FacteurCourse;
    }

    void Update()
    {
        bool groundedPlayer = _characterController.isGrounded;
        float horizontal = 0.0f;
        float vertical = 0.0f;

        float vitesseApplicable = _vitesse;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vitesseApplicable *= _augmentationCourse;
        }

        // On peut seulement se déplacer si on est au sol
        if (groundedPlayer)
        {
            horizontal = Input.GetAxis("Horizontal") * vitesseApplicable * Time.deltaTime;
            vertical = Input.GetAxis("Vertical") * vitesseApplicable * Time.deltaTime;


            Vector3 direction = new Vector3(horizontal, 0, vertical);
            direction = transform.TransformDirection(direction);

            _characterController.Move(direction);
        }

        // Gestion des sauts et de la gravité
        if (groundedPlayer && Input.GetButtonDown("Jump"))
        {
            // Sauter = appliquer une vitesse instantannée vers le haut
            _velocity.y = _forceSaut;
        }
        else if (groundedPlayer)
        {
            _velocity.y = 0;
        }

        // On applique toujours la formule de gravité
        _velocity.y += Physics.gravity.y * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }

    internal void ReplacerJoueur()
    {
        _characterController.enabled = false;
        transform.position = _positionInitiale;
        transform.rotation = _rotationInitiale;
        _characterController.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject == _objectif)
        {
            ReplacerJoueur();
        }
    }
}