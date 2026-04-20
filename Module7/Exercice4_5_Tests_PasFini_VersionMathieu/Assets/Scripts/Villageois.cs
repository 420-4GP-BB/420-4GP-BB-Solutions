using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Villageois : MonoBehaviour
{
    [SerializeField]
    private TMP_Text texteOr;

    private NavMeshAgent navMeshAgent;
    private int or = 0;

    public GameObject objectif;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (objectif == null)
        {
            objectif = TrouverOrPrecieux();

            if (navMeshAgent.isActiveAndEnabled)
            {
                navMeshAgent.SetDestination(objectif.transform.position);
            }
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

    public GameObject TrouverOrPrecieux()
    {
        int indexPrecieux = GameManager.Instance.TrouverOrPlusPrecieux(GameManager.Instance.ressources);
        return GameManager.Instance.ressources[indexPrecieux].gameObject;
    }
}