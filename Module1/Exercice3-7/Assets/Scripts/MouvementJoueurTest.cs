using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Test de deplacement de la balle (qui ne marchera pas avec les collisions)
 *
 * Auteur: Nicolas Hurtubise
 */
public class MouvementJoueurTest : MonoBehaviour
{
    private InputAction mouvement;

    private void Start()
    {
        mouvement = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 mouvementApplique = mouvement.ReadValue<Vector2>();
        Vector3 vitesse = 10 * new Vector3(mouvementApplique.x, 0, mouvementApplique.y);
        transform.position += vitesse * Time.deltaTime;
    }
}