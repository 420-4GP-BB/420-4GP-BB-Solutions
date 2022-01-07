using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementJoueur5 : MonoBehaviour
{
    [SerializeField] private float vitesse;
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
        Quaternion rotation = Quaternion.LookRotation(directionRotation, Vector3.up);
        transform.rotation = rotation;
        
        // Déplacement
        bool atteint = false;
        while (!atteint)
        {
            Vector3 direction = destination - transform.position;
            direction = Vector3.Normalize(direction);
            transform.position = Vector3.MoveTowards(transform.position, destination, 
                vitesse * Time.deltaTime);
            atteint = Vector3.Distance(destination, transform.localPosition) <= 0.2f;
            yield return null;
        }
    }
}
