using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Test de déplacement de la balle (qui ne marchera pas avec les collisions)
 *
 * Auteur: Nicolas Hurtubise
 */
public class MouvementJoueurTest : MonoBehaviour
{
    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 vitesse = 10 * new Vector3(_horizontal, 0, _vertical);
        transform.position += vitesse * Time.deltaTime;
    }
}