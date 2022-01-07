using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementJoueur7 : MonoBehaviour
{
    [SerializeField] private float vitesse;
    [SerializeField] private float vitesseRotation;

    private Rigidbody rb;
    [SerializeField] private Collider plancher;
    private Vector3 destination;
    private Coroutine deplacement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector3 positionCible = transform.position;
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == plancher)
            {
                positionCible = hit.point;
                positionCible.y = 0.5f;
                destination = positionCible;
                if (deplacement != null)
                {
                    StopCoroutine(deplacement);
                }
                deplacement = StartCoroutine(DeplacerJoueur());
            }
        }
    }

    private IEnumerator DeplacerJoueur()
    {
        // On fait la rotation
        Vector3 directionRotation = Vector3.Normalize(destination - transform.position);
        Quaternion initial = transform.rotation;
        Quaternion rotation = Quaternion.LookRotation(directionRotation, Vector3.up);
        bool rotationTerminee = false;
        float increment = 0.0f;

        while (! rotationTerminee)
        {
            Quaternion rotationIntermediaire = Quaternion.Lerp(initial, rotation, increment);
            increment += Time.fixedDeltaTime * vitesseRotation;
            rb.MoveRotation(rotationIntermediaire);
            rotationTerminee = increment >= 1.0f;
            yield return new WaitForFixedUpdate();
        }

        float distance = Vector3.Distance(transform.position, destination);
        while (distance >= 0.2f)
        {
            Vector3 direction = destination - transform.position;
            direction = Vector3.Normalize(direction);
            Vector3 speed = direction * vitesse;
            Vector3 nouveauPoint = transform.position + speed * Time.fixedDeltaTime;
            rb.MovePosition(nouveauPoint);
            distance = Vector3.Distance(transform.position, destination);
            yield return new WaitForFixedUpdate();
        }
    }
}
