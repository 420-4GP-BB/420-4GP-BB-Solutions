using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    [SerializeField] private float _vitesse;
    [SerializeField] private float _forceSaut;
    [SerializeField] private float _augmentationCourse = 3;
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

        // Exercice 2: on utilise SimpleMove avec la vitesse directement
        //_characterController.SimpleMove(vitesse);

        // Exercice 3 : Sauter
        bool toucheLeSol = _characterController.isGrounded;

        // Gestion des sauts et de la gravit�
        if (toucheLeSol && Input.GetButtonDown("Jump"))
        {
            // Sauter = appliquer une vitesse instantann�e vers le haut
            _velociteY = _forceSaut;
        }
        else if (toucheLeSol)
        {
            _velociteY = 0;
        }

        // On applique toujours la formule de gravit�
        _velociteY += Physics.gravity.y * Time.deltaTime;

        vitesse += new Vector3(0, _velociteY, 0);
        // Exercice 3 : puisqu'on doit appliquer d'autres forces verticalement,
        // SimpleMove est insuffisant. On remplace �a par un Move() et on g�re
        // la gravit� � la main
        Vector3 deplacement = Time.deltaTime * vitesse;
        _characterController.Move(deplacement);
    }

    private void ReplacerJoueur()
    {
        // Exercice 4 : notez ici, �a fonctionne un peu comme pour le Rigidbody.
        // Quand un objet a un CharacterController, on devrait UNIQUEMENT d�placer
        // l'objet via son CharacterController
        //
        // Si on souhaite le d�placer via une autre fa�on (ex.: le t�l�porter ici
        // via sa transform), on doit d'abord d�sactiver la composante puis
        // la r�activer � la fin
        _characterController.enabled = false;
        transform.position = _positionInitiale;
        transform.rotation = _rotationInitiale;
        _characterController.enabled = true;
    }

    // Exercice 4 : Notez ici, la m�thode de d�tection de collisions n'est
    // pas la m�me quand on a un CharacterController
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject == _objectif)
        {
            ReplacerJoueur();
        }
    }
}