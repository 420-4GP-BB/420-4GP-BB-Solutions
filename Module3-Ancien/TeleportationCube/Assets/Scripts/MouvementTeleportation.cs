using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementTeleportation : MonoBehaviour
{
    [SerializeField] private Collider colliderPlan;  // Le plan pour détecter où est le clic

    private Rigidbody _rbody;   // Le rigidbody
    private bool _mouvementRequis; // On déplace dans le FixedUpdate
    private Vector3 _prochainePosition; // L'endroit où on se déplace

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
                _prochainePosition = new Vector3(positionClic.Value.x, transform.localPosition.y, positionClic.Value.z);
                Debug.Log("Position finale: " + _prochainePosition.ToString());
                _mouvementRequis = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (_mouvementRequis)
        {
            _rbody.MovePosition(_prochainePosition);
            _mouvementRequis = false;
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
