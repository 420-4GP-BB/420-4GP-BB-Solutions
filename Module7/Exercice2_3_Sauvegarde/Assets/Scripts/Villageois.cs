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

    public int or = 0;
    public int plantes = 0;
    public int roches = 0;
    private int numeroRessourceChoisie = -1;
    private NavMeshAgent navMeshAgent;
    
    private StrategieChoixRessource strategieChoix;

    void Start()
    {
        // Exercice 2
        ChargerStrategie();
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

    // Exercice 2
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("TypeStrategie", (int)strategieChoix.Type);
    }

    public void MiseAJourTextes()
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

    // Exercice 2
    private void ChargerStrategie()
    {
        // 0 = Hasard (par defaut), 1 = Proche, 2 = Equilibre
        int type = PlayerPrefs.GetInt("TypeStrategie", 0);

        switch ((TypeStrategie)type)
        {
            case TypeStrategie.Hasard:
                strategieChoix = new StrategieChoixHasard();
                break;
            case TypeStrategie.Proche:
                strategieChoix = new StrategieChoixPlusProche();
                break;
            case TypeStrategie.Equilibre:
                strategieChoix = new StrategieChoixEquilibre();
                break;
        }
    }
}