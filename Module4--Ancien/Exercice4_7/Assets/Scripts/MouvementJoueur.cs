using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    private float _vitesse;
    private float _augmentationCourse = 3;

    [SerializeField] private float _forceSaut;
    private CharacterController _characterController;

    private Vector3 _positionInitiale;
    private Quaternion _rotationInitiale;
    private float _velociteY;
    [SerializeField] private GameObject _objectif;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _positionInitiale = transform.position;
        _rotationInitiale = transform.rotation;

        _vitesse = GestionnaireJeu.Instance.Vitesse;
        _augmentationCourse = GestionnaireJeu.Instance.FacteurAcceleration;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float magnitudeVitesse = _vitesse;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            magnitudeVitesse *= _augmentationCourse;
        }

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        var directionSelonPersonnage = transform.TransformDirection(direction);

        Vector3 vitesse = magnitudeVitesse * directionSelonPersonnage;

        bool toucheLeSol = _characterController.isGrounded;

        // Gestion des sauts et de la gravité
        if (toucheLeSol && Input.GetButtonDown("Jump"))
        {
            // Sauter = appliquer une vitesse instantannée vers le haut
            _velociteY = _forceSaut;
        }
        else if (toucheLeSol)
        {
            _velociteY = 0;
        }

        // On applique toujours la formule de gravité
        _velociteY += Physics.gravity.y * Time.deltaTime;

        vitesse += new Vector3(0, _velociteY, 0);
        Vector3 deplacement = Time.deltaTime * vitesse;
        _characterController.Move(deplacement);
    }

    private void ReplacerJoueur()
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