using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject prefabOr;
    public GameObject prefabPiege;

    public int nbRessource = 75;

    [HideInInspector]
    public List<Ressource> ressourcesListe = new();

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

    void Update()
    {
        if (nbRessource == 0) return;

        if (ressourcesListe.Count == 0)
        {
            CreerRessources();
        }
    }

    private void CreerRessources()
    {
        for (int i = 0; i < nbRessource; i++)
        {
            float positionX = Random.Range(-25, 25);
            float positionZ = Random.Range(-25, 25);
            Vector3 position = new Vector3(positionX, 0.5f, positionZ);

            int valeur = Random.Range(1, 30);
            GameObject or = prefabOr;

            // On change a un piege
            if (valeur < 5)
            {
                valeur = -15;
                or = prefabPiege;
            }

            GameObject nouvelOr = Instantiate(or, position, Quaternion.identity);
            Ressource ressource = nouvelOr.GetComponent<Ressource>();
            ressource.Valeur = valeur;

            ressourcesListe.Add(ressource);
        }
    }
}