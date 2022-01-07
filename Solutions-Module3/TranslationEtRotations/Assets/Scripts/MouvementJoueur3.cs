using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementJoueur3 : MonoBehaviour
{
    [SerializeField] private float vitesse;
    [SerializeField] private Collider plancher;

    private Vector3 depart;
    private Vector3 destination;
    private float pourcentageDeplacement;

    // Start is called before the first frame update
    void Start()
    {
        depart = destination = transform.position;
        pourcentageDeplacement = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            InterpreterClic();
        }

        pourcentageDeplacement += vitesse * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, destination, pourcentageDeplacement);
    }

    private Vector3 InterpreterClic()
    {
        Vector3 position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit = new RaycastHit();
        Vector3 positionCible = transform.position;
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == plancher)
            {
                positionCible = hit.point;
                positionCible.y = 0.5f;
                depart = transform.position;
                destination = positionCible;
                pourcentageDeplacement = 0.0f;
            }
        }
        return positionCible;
    }
}
