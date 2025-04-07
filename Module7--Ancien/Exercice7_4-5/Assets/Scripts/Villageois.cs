using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Villageois : MonoBehaviour
{
    public int Or = 0;
    public GameObject Objectif = null;

    private NavMeshAgent _navMeshAgent;
    [SerializeField] private TMP_Text texteOr;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Objectif == null)
        {
            Objectif = TrouverMeilleureRessource();

            if (Objectif != null && _navMeshAgent.enabled)
                _navMeshAgent.SetDestination(Objectif.transform.position);
        }
    }

    public GameObject TrouverMeilleureRessource()
    {
        var ressources = FindObjectsByType<Ressource>(FindObjectsSortMode.None);

        if (ressources.Length == 0)
            return null;

        int[] valeurs = new int[ressources.Length];
        for (int i = 0; i < ressources.Length; i++)
        {
            valeurs[i] = ressources[i].Valeur;
        }

        // CORRECTION APPORTÉE : on supprime la logique brisée de indexDepart et on remplace
        // ça par une vérification simple que le plus grand n'est pas négatif
        var index = Utilitaires.PlusGrandElementTableau(valeurs, 0);
        
        var valeur = ressources[index].Valeur;

        if (valeur < 0)
            return null;
        else
            return ressources[index].gameObject;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Ressource>(out var ressource))
        {
            Or += ressource.Valeur;
            MiseAJourUI();
            Destroy(other.gameObject);
        }
    }

    public void PerdreOr(int i)
    {
        Or -= i;
        MiseAJourUI();
    }

    private void MiseAJourUI()
    {
        if (texteOr != null)
            texteOr.text = "Or: " + Or;
    }
}