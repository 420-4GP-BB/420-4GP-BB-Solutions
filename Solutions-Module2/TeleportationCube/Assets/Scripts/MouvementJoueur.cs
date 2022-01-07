using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class MouvementJoueur : MonoBehaviour
{
    [SerializeField] private Collider colliderPlan;

    void Start()
    {
     
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 positionSouris = Input.mousePosition;
            Debug.Log("Souris: " + positionSouris);

            // Trouver le lien avec la caméra
            Ray ray = Camera.main.ScreenPointToRay(positionSouris);
            Debug.Log("Ray: " + ray.ToString());

            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Point de contact: " + hit.point);


                // Vérifier si l'objet touché est la plan.

                if (hit.collider == colliderPlan)
                {
                    // Déplacement requis est la soustraction du point de destination au point de départ.
                    Vector3 deplacementRequis = hit.point - transform.position;
                    deplacementRequis.y = 0;

                    // Avant, il faut trouver le déplacement requis en fonction de notre vue du monde.
                    transform.Translate(deplacementRequis);
                }
            }



        }
    }




}
