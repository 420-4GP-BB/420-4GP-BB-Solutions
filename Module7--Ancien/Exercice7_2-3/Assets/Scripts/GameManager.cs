using System;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsRessources;
    [SerializeField] private int nbRessources;

    private string NomFichierSauvegarde;

    public static GameManager Instance;
    public Ressource[] Ressources;
    public int NbRessourcesDisponibles { get; private set; }

    private void Awake()
    {
        NomFichierSauvegarde = Application.persistentDataPath + "/etat-jeu.json";

        // Valide qu'il y a un seul GameManager
        Debug.Assert(Instance == null);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(NomFichierSauvegarde))
        {
            Charger();
        }

        CreerRessources();
    }

    private void CreerRessources()
    {
        if (NbRessourcesDisponibles == 0)
            NbRessourcesDisponibles = nbRessources;

        Ressources = new Ressource[NbRessourcesDisponibles];
        // Crée les ressources au début du jeu
        for (int i = 0; i < NbRessourcesDisponibles; i++)
        {
            float x = Random.value * 50 - 25;
            float z = Random.value * 50 - 25;
            Vector3 pos = new Vector3(x, 0.5f, z);
            int choix = Random.Range(0, prefabsRessources.Length);
            var objet = Instantiate(prefabsRessources[choix], pos, Quaternion.identity);
            Ressources[i] = objet.GetComponent<Ressource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (NbRessourcesDisponibles == 0)
        {
            CreerRessources();
        }
    }

    public void DetruireRessource(int numeroRessourceChoisie)
    {
        Destroy(Ressources[numeroRessourceChoisie].gameObject);

        // Déplace le dernier objet dans cette case pour toujours
        // garder un tableau allant de 0 à NbRessourcesDisponibles
        //
        //  A B C D X Y Z  --> détruire D
        //  A B C Z X Y null
        Ressources[numeroRessourceChoisie] = Ressources[NbRessourcesDisponibles - 1];
        Ressources[NbRessourcesDisponibles - 1] = null;
        NbRessourcesDisponibles--;
    }

    private void OnApplicationQuit()
    {
        Sauvegarder();
    }

    public void Sauvegarder()
    {
        var villageois = FindObjectOfType<Villageois>();

        var etatJeu = new EtatJeu();
        etatJeu.Or = villageois.Or;
        etatJeu.Plantes = villageois.Plantes;
        etatJeu.Roches = villageois.Roches;
        etatJeu.NbRessourcesDisponibles = NbRessourcesDisponibles;

        string json = JsonUtility.ToJson(etatJeu);

        File.WriteAllText(NomFichierSauvegarde, json);
    }

    public void Charger()
    {
        var json = File.ReadAllText(NomFichierSauvegarde);
        
        EtatJeu etatJeu = JsonUtility.FromJson<EtatJeu>(json);

        var villageois = FindObjectOfType<Villageois>();
        villageois.Or = etatJeu.Or;
        villageois.Plantes = etatJeu.Plantes;
        villageois.Roches = etatJeu.Roches;

        NbRessourcesDisponibles = etatJeu.NbRessourcesDisponibles;
    }
}