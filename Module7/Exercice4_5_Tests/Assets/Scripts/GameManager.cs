using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject prefabOr;
    public GameObject prefabPiege;

    public int nombreRessourceCree = 75;

    [HideInInspector]
    public List<Ressource> listeRessources = new();

    // Patron singleton
    public static GameManager Instance;

    void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }

    void Start()
    {
        CreerRessources();
    }

    private void CreerRessources()
    {
        for (int i = 0; i < nombreRessourceCree; i++)
        {
            float positionX = Random.Range(-25, 25);
            float positionZ = Random.Range(-25, 25);
            Vector3 position = new Vector3(positionX, 0.5f, positionZ);

            int valeurAleatoire = Random.Range(1, 30);
            GameObject or = prefabOr;

            if (valeurAleatoire < 5)
            {
                // On change a un piege
                valeurAleatoire = -15;
                or = prefabPiege;
            }

            GameObject nouvelOr = Instantiate(or, position, Quaternion.identity);
            Ressource ressource = nouvelOr.GetComponent<Ressource>();
            ressource.Valeur = valeurAleatoire;

            listeRessources.Add(ressource);
        }
    }

    public void DetruireRessource(Ressource ressource)
    {
        listeRessources.Remove(ressource);
        Destroy(ressource.gameObject);
    }
}