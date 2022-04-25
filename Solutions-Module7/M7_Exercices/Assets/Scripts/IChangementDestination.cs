using UnityEngine;
using UnityEngine.AI;

public interface IChangementDestination
{
    NavMeshAgent Agent { get; }
    void ChangerDestination(Transform nouvelle);
}

