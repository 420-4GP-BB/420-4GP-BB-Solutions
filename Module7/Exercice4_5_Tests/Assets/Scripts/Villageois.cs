using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Villageois : MonoBehaviour
{
    [SerializeField]
    private TMP_Text texteOr;

    [HideInInspector]
    public Ressource ressourceChoisi = null;

    [HideInInspector]
    public int nombreOr = 0;
    
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (ressourceChoisi == null)
        {
            ressourceChoisi = TrouverOrPlusPrecieux(GameManager.Instance.ressourcesListe);

            if (ressourceChoisi != null && navMeshAgent.isActiveAndEnabled)
            {
                navMeshAgent.SetDestination(ressourceChoisi.transform.position);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ressource hitRessource))
        {
            nombreOr += hitRessource.Valeur;
            if (texteOr != null)
            {
                texteOr.text = "Or: " + nombreOr;
            }

            GameManager.Instance.ressourcesListe.Remove(hitRessource);
            Destroy(hitRessource.gameObject);
        }
    }

    public Ressource TrouverOrPlusPrecieux(List<Ressource> ressourcesListe)
    {
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(ressourcesListe);
        
        if (plusPrecieux == null || plusPrecieux.Valeur < 0) return null;
        else return (Ressource)plusPrecieux;
    }
}