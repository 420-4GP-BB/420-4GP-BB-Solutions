using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Exercice2Agent : MonoBehaviour
{
    [SerializeField]
    private GameObject terrain;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 positionSouris = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(positionSouris);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == terrain)
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

    }
}
