using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabsRessources;

    [SerializeField]
    private int nbRessources;

    [HideInInspector]
    public List<Ressource> ressources;

    public static GameManager Instance;

    void Awake()
    {
        // Valide qu'il y a un seul GameManager
        Debug.Assert(Instance == null);
        Instance = this;
    }

	void Start()
	{
		CreerRessources();
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

    void Update()
    {
        if (ressources.Count == 0)
        {
            CreerRessources();
        }
    }

    public void DetruireRessource(int numeroRessourceChoisie)
    {
        Ressource ressource = ressources[numeroRessourceChoisie];
        Destroy(ressource.gameObject);
        ressources.Remove(ressource);
    }
}
