using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Villageois : MonoBehaviour
{
    [SerializeField]
    private TMP_Text texteOr;

    private NavMeshAgent navMeshAgent;
    private int or = 0;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (navMeshAgent.pathPending) return;

        if (navMeshAgent.remainingDistance <= 1f)
        {
            AllerVersOrPrecieux();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ressource>(out var ressource))
        {
            or += ressource.valeur;
            texteOr.text = "Or: " + or;

            GameManager.Instance.ressources.Remove(ressource);
            Destroy(collision.gameObject);
        }
    }

    private void AllerVersOrPrecieux()
    {
        int indexPrecieux = GameManager.Instance.TrouverOrPlusPrecieux(GameManager.Instance.ressources);
        navMeshAgent.SetDestination(GameManager.Instance.ressources[indexPrecieux].transform.position);
    }
}