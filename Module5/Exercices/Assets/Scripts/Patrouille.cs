using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrouille : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pointPatrouilles;

    private NavMeshAgent agent;
    private Animator animateur;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animateur = GetComponent<Animator>();

        animateur.SetBool("Walk", true);
        ChoisirPointAleatoire();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            ChoisirPointAleatoire();
        }
    }

    private void ChoisirPointAleatoire()
    {
        int nombreAleatoire = Random.Range(0, pointPatrouilles.Count);
        Vector3 pointSelectionne = pointPatrouilles[nombreAleatoire].transform.position;
        agent.SetDestination(pointSelectionne);
    }
}
