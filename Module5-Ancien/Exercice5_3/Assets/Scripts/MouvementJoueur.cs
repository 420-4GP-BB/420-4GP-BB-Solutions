using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Permet de déplacer un joueur avec un CharacterController
/// Le saut et la chute sont implémentés
/// </summary>
public class MouvementJoueur : MonoBehaviour
{
    private CharacterController _characterController;
    private float _vitesse;
    private float _gravite;
    private float _impulsion;
    private Vector3 _velocity;
    private Vector3 _positionInitiale;
    private Quaternion _rotationInitiale;
    private GameManager _gameManager;
    private GameObject _objectif;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _gravite = -9.8f;
        _impulsion = 1.0f;
        _positionInitiale = transform.position;
        _rotationInitiale = transform.rotation;
        _velocity = Vector3.zero;
        _vitesse = 15.0f;
        _gameManager = GameManager.Instance;
        _vitesse = _gameManager.Vitesse;
        _objectif = GameObject.Find("Objectif");
    }


    /// <summary>
    /// Le code est inspiré de l'exemple trouvé sur https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    /// </summary>
    void Update()
    {
        bool groundedPlayer = _characterController.isGrounded;
        

        // Si on est sur le sol, on ne doit pas descendre
        if (groundedPlayer && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        // Déplacement selon les axes

        float vitesseApplicable = _vitesse;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vitesseApplicable *= _gameManager.FacteurAcceleration;
        }
        float horizontal = Input.GetAxis("Horizontal") * vitesseApplicable * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * vitesseApplicable * Time.deltaTime;


        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);
        _characterController.Move(direction);

        if (_velocity.y == 0 && Input.GetButtonDown("Jump"))
        {
            _velocity.y += Mathf.Sqrt(_impulsion * -3.0f * _gravite);
        }

        _velocity.y += _gravite* Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject == _objectif)
        {
            SceneManager.LoadScene("Victoire");
        }
        else if (hit.gameObject.tag == "Ennemi")
        {
            // SceneManager.LoadScene("Defaite");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ennemi")
        {
            SceneManager.LoadScene("Defaite");
        }
    }

}
