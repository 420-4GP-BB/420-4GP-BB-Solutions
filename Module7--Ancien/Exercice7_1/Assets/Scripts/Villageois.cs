using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Villageois : MonoBehaviour
{
    private int or;
    private int plantes;
    private int roches;
    private int numeroRessourceChoisie = -1;
    private NavMeshAgent _navMeshAgent;
    
    private StrategieChoixRessource strategieChoix = new StrategieChoixHasard();

    [SerializeField] private TMP_Text texteOr;
    [SerializeField] private TMP_Text textePlantes;
    [SerializeField] private TMP_Text texteRoches;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (numeroRessourceChoisie == -1)
        {
            ChoisirRessource();
        }
        else if (numeroRessourceChoisie != -1 && Vector3.Distance(_navMeshAgent.destination, transform.position) < 1.4f)
        {
            var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];

            var ressource = objet.GetComponent<Ressource>();
            if (ressource.Type == TypeRessource.Or)
                or++;
            else if (ressource.Type == TypeRessource.Plante)
                plantes++;
            else if (ressource.Type == TypeRessource.Roche)
                roches++;

            MiseAJourTextes();
            
            GameManager.Instance.DetruireRessource(numeroRessourceChoisie);
            
            ChoisirRessource();
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
        this.strategieChoix = strategie;
        ChoisirRessource();
    }

    private void ChoisirRessource()
    {
        // Choix au hasard
        int nbRessourcesDisponibles = GameManager.Instance.NbRessourcesDisponibles;

        if (nbRessourcesDisponibles == 0)
        {
            numeroRessourceChoisie = -1;
        }
        else
        {
            numeroRessourceChoisie = strategieChoix.ChoisirRessource(this, GameManager.Instance.Ressources,
                GameManager.Instance.NbRessourcesDisponibles);

            var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];
            var ressource = objet.GetComponent<Ressource>();
            _navMeshAgent.destination = objet.transform.position;
        }
    }
}