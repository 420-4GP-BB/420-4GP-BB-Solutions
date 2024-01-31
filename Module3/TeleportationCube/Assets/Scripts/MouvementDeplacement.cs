using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/**
 * Classe qui déplace un objet en fonction d'un clic sur un plan
 * 
 * Auteur: Éric Wenaas
 */

public class MouvementDeplacement : MonoBehaviour
{
    [SerializeField] private Collider colliderPlan;  // Le plan pour détecter où est le clic
    [SerializeField] private float vitesse;  // La vitesse de déplacement

    private Rigidbody _rbody;   // Le rigidbody
    private Coroutine _deplacement; // On conserve une référence de la coroutine pour pouvoir l'arêter.

    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
        _deplacement = StartCoroutine(DeplacerCube(_rbody.position));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = DeterminerClic();
            if (positionClic != null)
            {
                Vector3 positionFinale = positionClic.Value;
                StopCoroutine(_deplacement);
                _deplacement = StartCoroutine(DeplacerCube(positionFinale));
            }
        }
    }

    /**
     * Méthode qui vérifie si le clic est sur le plan. Si le clic est à l'extérieur
     * alors, on retourne null
     */
    private Vector3? DeterminerClic()
    {
        Vector3 positionSouris = Input.mousePosition;
        Vector3? pointClique = null;

        // Trouver le lien avec la caméra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet touché est le plan.
            if (hit.collider == colliderPlan)
            {
                // Le vecteur est initialise ici car le clic est sur le plan
                pointClique = hit.point;
            }
        }
        return pointClique;
    }


    /**
     * Méthode qui déplace l'objet dans la direction de la position finale.
     * 
     * Doit être déclenché dans une coroutine.
     */
    private IEnumerator DeplacerCube(Vector3 positionFinale)
    {

        bool termine = false;
        while (!termine)
        {
            Vector3 positionActuelle = transform.position;
            float distance = Vector3.Distance(positionActuelle, positionFinale);

            if (distance >= 0.1f)
            {
                Vector3 direction = positionFinale - positionActuelle;
                direction = direction.normalized;
                Debug.Log(direction.ToString());
                Vector3 nouvellePosition = transform.position + (direction * vitesse * Time.fixedDeltaTime);

                if (Vector3.Distance(positionActuelle, nouvellePosition) > Vector3.Distance(positionActuelle, positionFinale))
                {
                    _rbody.MovePosition(positionFinale);
                }
                else
                {
                    _rbody.MovePosition(nouvellePosition);
                }

                yield return new WaitForFixedUpdate();
            }
            else
            {
                _rbody.MovePosition(positionFinale);
                termine = true;
            }
        }
        yield return new WaitForFixedUpdate();
    }
}
