using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui fait patrouiller les champignons en utilisant un NavMesh
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class PatrouilleMonstre : MonoBehaviour
{
    /// <summary>
    /// Les points de la patrouille
    /// </summary>
    [SerializeField] private Transform[] pointsPatrouille;

    /// <summary>
    /// Le prochain point à atteindre dans la patrouille
    /// </summary>
    private int indicePointPatrouille;

    /// <summary>
    /// Le contrôleur d'animation du champignon
    /// </summary>
    private Animator controlleurAnimation;

    /// <summary>
    /// L'agent pour gérer le déplacement du monstre
    /// </summary>
    private NavMeshAgent agentAI;

    /// <summary>
    ///  Valeur qui détermine dans quelle direction de la patrouille on se dirige.
    /// </summary>
    private bool aller;


    void Start()
    {
        aller = true;
        agentAI = GetComponent<NavMeshAgent>();
        indicePointPatrouille = 0;
        controlleurAnimation = GetComponent<Animator>();
        agentAI.SetDestination(pointsPatrouille[indicePointPatrouille].position);
    }

    void Update()
    {
        Vector3 positionActuelle = transform.position;

        if (Vector3.Distance(positionActuelle, agentAI.destination) <= 0.1f)
        {
            if (aller)
            {
                indicePointPatrouille++;
                if (indicePointPatrouille == pointsPatrouille.Length)
                {
                    aller = false;
                    indicePointPatrouille = pointsPatrouille.Length - 1;
                }
            }
            else
            {
                indicePointPatrouille--;
                if (indicePointPatrouille < 0)
                {
                    aller = true;
                    indicePointPatrouille = 0;
                }

            }
           // controlleurAnimation.SetBool("Run", true);
            agentAI.SetDestination(positionActuelle);
        }
    }
}
