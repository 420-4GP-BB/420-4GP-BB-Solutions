using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    [SerializeField] private float _vitesse;
    private CharacterController _characterController;
    private float _augmentationCourse;
    private float _gravite;
    private float _impulsion;
    private Vector3 _positionInitiale;
    private Quaternion _rotationInitiale;
    private Vector3 _velocity;
    private GameObject _objectif;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _augmentationCourse = 1.5f;
        _gravite = -9.8f;
        _impulsion = 1.0f;
        _positionInitiale = transform.position;
        _rotationInitiale = transform.rotation;
        _objectif = GameObject.Find("Objectif");
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

        horizontal = Input.GetAxis("Horizontal") * vitesseApplicable * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * vitesseApplicable * Time.deltaTime;


        // Si on est sur le sol, on ne doit plus descendre
        if (groundedPlayer && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);
        
        _characterController.Move(direction);

        if (_velocity.y == 0 && Input.GetButtonDown("Jump"))
        {
            _velocity.y += Mathf.Sqrt(_impulsion * -3.0f * _gravite);
        }

        _velocity.y += _gravite * Time.deltaTime;
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
        if (hit.gameObject == GameObject.Find("Objectif"))
        {
            ReplacerJoueur();
        }
    }
}
