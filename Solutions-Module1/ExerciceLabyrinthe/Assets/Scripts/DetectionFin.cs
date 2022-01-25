using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Classe qui permet de détecter qu'on a atteint l'objectif.
 * Elle replace le joueur à sa position initiale.
 * 
 * Auteur: Éric Wenaas
 */
public class DetectionFin : MonoBehaviour
{
    [SerializeField] private GameObject joueur; // Le joueur qu'on surveille. Quand il tombe dans la boîte, on le replace
    
    
    private Vector3 _positionDepart; // La position de départ du joueur

    // Start is called before the first frame update
    void Start()
    {
        _positionDepart = joueur.transform.position;
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == joueur)
        {
            

            StartCoroutine(ReplacerJoueur());
        }
    }


    /**
     * Coroutine qui attend et replace le joueur à sa position intiale
     */
    private IEnumerator ReplacerJoueur()
    {
        // On attemd deux secondes
        yield return new WaitForSeconds(2.0f);

        // On replace le joueur. Il faut arrêter le mouvement et la rotation également
        joueur.transform.position = _positionDepart;
        Rigidbody rbody = joueur.GetComponent<Rigidbody>();
        rbody.velocity = Vector3.zero;
        rbody.angularVelocity = Vector3.zero;

    }
}
