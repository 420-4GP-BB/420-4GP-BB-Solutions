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
    [SerializeField] private float _forceSaut;
    private Vector3 _velocity;
    private GameManager _gameManager;
    private GameObject _objectif;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _velocity = Vector3.zero;
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
        float horizontal = 0.0f;
        float vertical = 0.0f;

        float vitesseApplicable = _vitesse;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vitesseApplicable *= GameManager.Instance.FacteurAcceleration;
        }

        horizontal = Input.GetAxis("Horizontal") * vitesseApplicable * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * vitesseApplicable * Time.deltaTime;


        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);

        _characterController.Move(direction);

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
