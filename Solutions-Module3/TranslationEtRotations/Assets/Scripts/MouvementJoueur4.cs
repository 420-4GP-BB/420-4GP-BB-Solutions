using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementJoueur4 : MonoBehaviour
{
    [SerializeField] private float vitesse;
    [SerializeField] private Collider plancher;

    private Rigidbody rb;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
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


    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, destination);
        if (distance >= 0.2f)
        {
            Vector3 direction = destination - transform.position;
            direction = Vector3.Normalize(direction);
            Vector3 speed = direction * vitesse;
            Vector3 nouveauPoint = transform.position + speed * Time.deltaTime;
            Debug.Log("Position: " + transform.position.ToString() + " NouveauPoint: " + nouveauPoint.ToString());
            rb.MovePosition(nouveauPoint);
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
            }
        }
    }
}
