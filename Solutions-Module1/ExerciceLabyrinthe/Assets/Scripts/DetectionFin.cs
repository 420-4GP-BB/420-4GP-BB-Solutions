using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Rigidbody rbody = joueur.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(2.0f);
        joueur.transform.position = _positionDepart;
        rbody.velocity = Vector3.zero;
        rbody.angularVelocity = Vector3.zero;
    }
}
