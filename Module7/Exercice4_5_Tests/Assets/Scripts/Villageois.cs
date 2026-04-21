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
            ressourceChoisi = TrouverOrPlusPrecieux(GameManager.Instance.listeRessources);
            ChangerDestination();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ressource ressourceHit))
        {
            nombreOr += ressourceHit.Valeur;
            GameManager.Instance.DetruireRessource(ressourceHit);

            MettreAJourIU();
        }
    }

    public Ressource TrouverOrPlusPrecieux(List<Ressource> listeRessources)
    {
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(listeRessources);
        
        if (plusPrecieux == null || plusPrecieux.Valeur < 0)
        {
            return null;
        }
        else
        {
            return (Ressource)plusPrecieux;
        }
    }

    private void ChangerDestination()
    {
        if (ressourceChoisi != null && navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.SetDestination(ressourceChoisi.transform.position);
        }
    }

    private void MettreAJourIU()
    {
        if (texteOr != null)
        {
            texteOr.text = "Or: " + nombreOr;
        }
    }
}