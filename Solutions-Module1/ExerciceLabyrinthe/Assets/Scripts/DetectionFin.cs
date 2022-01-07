using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionFin : MonoBehaviour
{
    [SerializeField] private GameObject joueur;
    private Vector3 positionDepart;

    private Rigidbody bodyJoueur;
    // Start is called before the first frame update
    void Start()
    {
        positionDepart = joueur.transform.position;
        bodyJoueur = joueur.GetComponent<Rigidbody>();
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
        joueur.transform.position = positionDepart;
        bodyJoueur.velocity = Vector3.zero;
        bodyJoueur.angularVelocity = Vector3.zero;
    }
}
