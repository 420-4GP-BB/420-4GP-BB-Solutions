using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionFin : MonoBehaviour
{
    [SerializeField] private GameObject joueur;
    private Vector3 positionDepart;

    private Rigidbody bodyJoueur;
    private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        positionDepart = joueur.transform.position;
        bodyJoueur = joueur.GetComponent<Rigidbody>();
        _controller = joueur.GetComponent<CharacterController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == joueur)
        {
            StartCoroutine(ReplacerJoueur());
        }
    }

    private IEnumerator ReplacerJoueur()
    {
        yield return new WaitForSeconds(2.0f);
        _controller.enabled = false;
        joueur.transform.position = positionDepart;
        bodyJoueur.velocity = Vector3.zero;
        bodyJoueur.angularVelocity = Vector3.zero;
        _controller.enabled = true;
    }
}
