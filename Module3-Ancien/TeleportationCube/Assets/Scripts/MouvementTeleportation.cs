using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class MouvementTeleportation : MonoBehaviour
{
    [SerializeField] private Collider colliderPlan;  // Le plan pour détecter où est le clic

    private Rigidbody _rbody;   // Le rigidbody

    void Start()
    {
        _rbody = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = DeterminerClic();
            if (positionClic != null)
            {
                Vector3 positionFinale = new Vector3(positionClic.Value.x, transform.localPosition.y, positionClic.Value.z);
                Debug.Log("Position finale: " + positionFinale.ToString());
                _rbody.MovePosition(positionFinale);                
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
            Debug.Log("Point de contact: " + hit.point);

            // Vérifier si l'objet touché est le plan.
            if (hit.collider == colliderPlan)
            {
                // Le vecteur est initialise ici car le clic est sur le plan
                Vector3 position = hit.point;
                pointClique = new Vector3(position.x, position.y, position.z);
            }
        }
        return pointClique;
    }
}
