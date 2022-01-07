using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MouvementJoueur6 : MonoBehaviour
{
    [SerializeField] private float vitesse;
    [SerializeField] private float vitesseRotation;
    [SerializeField] private Collider plancher;
    
    private Coroutine deplacement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            InterpreterClic();
        }
    }
    
    private void InterpreterClic()
    {
        Vector3 position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == plancher)
            {
                Vector3 positionCible = hit.point;
                positionCible.y = 0.5f;
                if (deplacement != null)
                {
                    StopCoroutine(deplacement);
                }
                deplacement = StartCoroutine(DeplacerObjet(positionCible));
            }
        }
    }

    
    private IEnumerator DeplacerObjet(Vector3 destination)
    {
        Vector3 directionRotation = Vector3.Normalize(destination - transform.position);
        Quaternion initial = transform.rotation;
        Quaternion rotation = Quaternion.LookRotation(directionRotation, Vector3.up);
        float increment = 0.0f;
        bool rotationTerminee = false;

        while (! rotationTerminee)
        {
            transform.rotation = Quaternion.Slerp(initial, rotation, increment);
            increment += Time.deltaTime * vitesseRotation;
            rotationTerminee = increment >= 1.0f;
            yield return null;
        }

        
        // Déplacement
        bool atteint = false;
        while (!atteint)
        {
            Vector3 direction = destination - transform.position;
            direction = Vector3.Normalize(direction);
            transform.position = Vector3.MoveTowards(transform.position, destination, 
                vitesse * Time.deltaTime);
            yield return null;
            atteint = Vector3.Distance(destination, transform.localPosition) <= 0.2f;
        }
    }
}
