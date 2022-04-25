using UnityEngine;
using UnityEngine.AI;

public class ChangementDestinationNavMesh : MonoBehaviour, IChangementDestination
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void ChangerPositionCible(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public bool DestinationAtteinte()
    {
        return (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);
    }

    public void Arreter()
    {
        agent.enabled = false;
    }

    public void Reprendre()
    {
        agent.enabled = true;
    }

}
