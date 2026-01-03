using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Classe qui impl�mente un mouvement avec les touches de direction.
 *
 * Auteur: �ric Wenaas
 */
public class MouvementJoueur : MonoBehaviour
{
    [SerializeField] private float niveauForce; // Le niveau de force � appliquer

    private Rigidbody _rbody; // Le rigidbody o� on applique la force
    private Vector3 _positionDepart;

    private InputAction _move;

    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
        _positionDepart = transform.position;

        _move = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        var mouvement = _move.ReadValue<Vector2>();
        Vector3 force = new Vector3(mouvement.x, 0, mouvement.y);
        force *= niveauForce;
        _rbody.AddForce(force);
    }

    public void ReplacerJoueur()
    {
        transform.position = _positionDepart;
        _rbody.linearVelocity = Vector3.zero;
        _rbody.angularVelocity = Vector3.zero;
    }
}