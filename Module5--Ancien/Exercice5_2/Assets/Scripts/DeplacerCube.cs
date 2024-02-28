using UnityEngine;
using UnityEngine.AI;

public class DeplacerCube : MonoBehaviour
{
    [SerializeField] private Collider _plan;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? pointClique = Utilitaires.DeterminerClic(_plan);
            if (pointClique != null)
            {
                _agent.destination = pointClique.Value;
            }
        }
    }
}