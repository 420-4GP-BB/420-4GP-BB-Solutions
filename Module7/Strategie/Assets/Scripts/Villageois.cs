using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Villageois : MonoBehaviour
{
    [SerializeField]
    private TMP_Text texteOr;

    [SerializeField]
    private TMP_Text textePlantes;

    [SerializeField]
    private TMP_Text texteRoches;

    private int or = 0;
    private int plantes = 0;
    private int roches = 0;
    private int numeroRessourceChoisie = -1;
    private NavMeshAgent navMeshAgent;
    
    private StrategieChoixRessource strategieChoix;

    void Start()
    {
        strategieChoix = new StrategieChoixHasard();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (numeroRessourceChoisie == -1)
        {
            AllerVersProchaineRessource();
        }
        // Asse proche pour prendre la ressource
        else if (Vector3.Distance(transform.position, navMeshAgent.destination) < 1.4f)
        {
            TypeRessource typeRessource = GameManager.Instance.ressources[numeroRessourceChoisie].type;

            if (typeRessource == TypeRessource.Or) or++;
            else if (typeRessource == TypeRessource.Plante) plantes++;
            else if (typeRessource == TypeRessource.Roche) roches++;
            
            MiseAJourTextes();

            GameManager.Instance.DetruireRessource(numeroRessourceChoisie);
            AllerVersProchaineRessource();
        }
    }

    private void MiseAJourTextes()
    {
        texteOr.text = "Or: " + or;
        textePlantes.text = "Plantes: " + plantes;
        texteRoches.text = "Roches: " + roches;
    }

    public void ChangerStrategieChoix(StrategieChoixRessource strategie)
    {
        strategieChoix = strategie;
        AllerVersProchaineRessource();
    }

    private void AllerVersProchaineRessource()
    {
        List<Ressource> ressources = GameManager.Instance.ressources;

        if (ressources.Count == 0)
        {
            numeroRessourceChoisie = -1;
        }
        else
        {
            numeroRessourceChoisie = strategieChoix.ChoisirRessource(this, ressources);

            Ressource ressource = ressources[numeroRessourceChoisie];
            navMeshAgent.SetDestination(ressource.transform.position);
        }
    }
}