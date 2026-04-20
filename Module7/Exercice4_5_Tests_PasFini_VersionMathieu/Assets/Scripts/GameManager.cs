using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabOr;

    [SerializeField]
    private GameObject prefabPiege;

    [SerializeField]
    private int nbOr = 75;

    [HideInInspector]
    public List<Ressource> ressources;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CreerRessources();
    }

    void Update()
    {
        if (ressources.Count == 0)
        {
            CreerRessources();
        }
    }

    private void CreerRessources()
    {
        for (int i = 0; i < nbOr; i++)
        {
            float positionX = Random.Range(-25, 25);
            float positionZ = Random.Range(-25, 25);
            Vector3 position = new Vector3(positionX, 0.5f, positionZ);

            int valeur = Random.Range(1, 30);
            GameObject or = prefabOr;

            if (valeur < 5)
            {
                valeur = -15;
                or = prefabPiege;
            }

            GameObject nouvelOr = Instantiate(or, position, Quaternion.identity);
            Ressource nouvelOrScript = nouvelOr.GetComponent<Ressource>();
            nouvelOrScript.valeur = valeur;

            ressources.Add(nouvelOrScript);
        }
    }

    public int TrouverOrPlusPrecieux(List<Ressource> ressources)
    {
        // Ajout pour corriger cas limite 2
        if (ressources.Count == 0) return -1;

        int indexMax = 0;
        int valeurMax = ressources[0].valeur;

        for (int i = 0; i < ressources.Count; i++)
        {
            if (valeurMax < ressources[i].valeur)
            {
                valeurMax = ressources[i].valeur;
                indexMax = i;
            }
        }

        return indexMax;
    }
}