using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Test de déplacement de la balle (qui ne marchera pas avec les collisions)
 *
 * Auteur: Nicolas Hurtubise
 */
public class MouvementJoueurTest : MonoBehaviour
{
    private InputAction _move;

    private void Start()
    {
        _move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 mouvement = _move.ReadValue<Vector2>();
        Vector3 vitesse = 10 * new Vector3(mouvement.x, 0, mouvement.y);
        transform.position += vitesse * Time.deltaTime;
    }
}