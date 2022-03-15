using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui illustre le fonctionnement du NavMesh Navigator
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class MouvementMonstre : MonoBehaviour
{
    /// <summary>
    /// Le collider sur lequel on teste une collision.
    /// </summary>
    [SerializeField] private Collider colliderObjet;

    /// <summary>
    /// L'agent pour déplacer le monstre.
    /// </summary>
    private NavMeshAgent agentAI;

    void Start()
    {
        agentAI = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = DeterminerClic(colliderObjet);

            if (positionClic != null)
            {
                // Ajuste le point en fonction du y du monstre.
                positionClic = new Vector3(positionClic.Value.x, transform.position.y, positionClic.Value.z);   

                agentAI.SetDestination(positionClic.Value);
            }
        }
    }

    /// <summary>
    /// Détermine si la souris est sur le collider.
    /// </summary>
    /// <param name="collider">Le collider avec lequel on recherche le contact</param>
    /// <returns>Le point s'il y a un contact et null sinon</returns>
    private Vector3? DeterminerClic(Collider collideObjet)
    {
        Vector3 positionSouris = Input.mousePosition;
        Vector3? pointClique = null;

        // Trouver le lien avec la caméra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet touché est le plan.
            if (hit.collider == collideObjet)
            {
                // Le vecteur est initialise ici car le clic est sur le plan
                Vector3 position = hit.point;
                pointClique = new Vector3(position.x, position.y, position.z);
            }
        }
        return pointClique;
    }
}
