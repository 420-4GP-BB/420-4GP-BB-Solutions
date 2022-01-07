using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementJoueur1 : MonoBehaviour
{
    [SerializeField] private float vitesse;
    [SerializeField] private Collider plancher;
    
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
                StartCoroutine(DeplacerObjet(positionCible));
            }
        }
    }

    private IEnumerator DeplacerObjet(Vector3 destination)
    {
        bool atteint = false;
        while (!atteint)
        {
            Vector3 direction = destination - transform.position;
            direction = Vector3.Normalize(direction);
            transform.Translate(direction * (vitesse * Time.deltaTime));
            atteint = Vector3.Distance(destination, transform.position) <= 0.2f;
            yield return null;
        }
    }
}
