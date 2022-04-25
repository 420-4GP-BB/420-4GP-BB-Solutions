using UnityEngine;
using UnityEngine.AI;

public class ChangementDestinationNavMesh : MonoBehaviour, IChangementDestination
{
    private NavMeshAgent agent;

    public NavMeshAgent Agent
    {
        get { return agent; }
    }

    public void ChangerDestination(Transform nouvelle)
    {
        agent.SetDestination(nouvelle.position);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
