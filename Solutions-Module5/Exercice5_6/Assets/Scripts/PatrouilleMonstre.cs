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
        controlleurAnimation.SetBool("Run", true);
    }

    void Update()
    {
        Vector3 positionActuelle = transform.position;

        if (agentAI.remainingDistance <= agentAI.stoppingDistance)
        {
            if (aller)
            {
                indicePointPatrouille++;
            }
            else
            {
                indicePointPatrouille--;
            }

            if (indicePointPatrouille == pointsPatrouille.Length)
            {
                aller = false;
            }

            if (indicePointPatrouille < 0)
            {
                aller = true;
            }
            if (indicePointPatrouille >= 0 && indicePointPatrouille < pointsPatrouille.Length)
            {
                controlleurAnimation.SetBool("Run", true);
                agentAI.SetDestination(pointsPatrouille[indicePointPatrouille].position);
            }
        }
    }
}
