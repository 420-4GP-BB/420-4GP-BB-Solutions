using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabsRessources;

    [SerializeField]
    private int nbRessources;

    [SerializeField]
    private Villageois villageois; // Exercice 3

    [HideInInspector]
    public List<Ressource> ressources;

    public static GameManager Instance;

    private string nomFichierSauvegarde; // Exercice 3

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Exercice 3
        nomFichierSauvegarde = Application.persistentDataPath + "/etat-jeu.json";
        ChargerEtatJeu();
    }

    void Update()
    {
        if (ressources.Count == 0)
        {
            CreerRessources();
        }
    }

    // Exercice 3
    void OnApplicationQuit()
    {
        SauvegarderEtatJeu();
    }

    private void CreerRessources()
    {
        for (int i = 0; i < nbRessources; i++)
        {
            float positionX = Random.Range(-25, 25);
            float positionZ = Random.Range(-25, 25);
            Vector3 position = new Vector3(positionX, 0.5f, positionZ);

            int indexAleatoire = Random.Range(0, prefabsRessources.Count);
            GameObject ressourceAleatoire = Instantiate(prefabsRessources[indexAleatoire], position, Quaternion.identity);
            ressources.Add(ressourceAleatoire.GetComponent<Ressource>());
        }
    }

    public void DetruireRessource(int numeroRessourceChoisie)
    {
        Ressource ressource = ressources[numeroRessourceChoisie];
        Destroy(ressource.gameObject);
        ressources.Remove(ressource);
    }

    // Exercice 3
    private void SauvegarderEtatJeu()
    {
        EtatJeu etatJeu = new EtatJeu
        {
            orCollecte = villageois.or,
            plantesCollecte = villageois.plantes,
            rochesCollecte = villageois.roches,
            ressourcesRestantes = ressources.Count
        };

        string json = JsonUtility.ToJson(etatJeu);
        File.WriteAllText(nomFichierSauvegarde, json);
    }

    // Exercice 3
    private void ChargerEtatJeu()
    {
        if (File.Exists(nomFichierSauvegarde))
        {
            string json = File.ReadAllText(nomFichierSauvegarde);
            EtatJeu etatJeu = JsonUtility.FromJson<EtatJeu>(json);

            villageois.or = etatJeu.orCollecte;
            villageois.plantes = etatJeu.plantesCollecte;
            villageois.roches = etatJeu.rochesCollecte;
            villageois.MiseAJourTextes();

            nbRessources = etatJeu.ressourcesRestantes;
        }

        CreerRessources();
    }
}