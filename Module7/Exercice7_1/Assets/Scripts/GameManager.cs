using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsRessources;
    [SerializeField] private int nbRessources;

    public static GameManager Instance;
    public Ressource[] Ressources;
    public int NbRessourcesDisponibles { get; private set; }

    private void Awake()
    {
        // Valide qu'il y a un seul GameManager
        Debug.Assert(Instance == null);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreerRessources();
    }

    private void CreerRessources()
    {
        Ressources = new Ressource[nbRessources];
        // Cr�e les ressources au d�but du jeu
        for (int i = 0; i < nbRessources; i++)
        {
            float x = Random.value * 50 - 25;
            float z = Random.value * 50 - 25;
            Vector3 pos = new Vector3(x, 0.5f, z);
            int choix = Random.Range(0, prefabsRessources.Length);
            var objet = Instantiate(prefabsRessources[choix], pos, Quaternion.identity);
            Ressources[i] = objet.GetComponent<Ressource>();
        }

        NbRessourcesDisponibles = nbRessources;
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

        // D�place le dernier objet dans cette case pour toujours
        // garder un tableau allant de 0 � NbRessourcesDisponibles
        //
        //  A B C D X Y Z  --> d�truire D
        //  A B C Z X Y null
        Ressources[numeroRessourceChoisie] = Ressources[NbRessourcesDisponibles - 1];
        Ressources[NbRessourcesDisponibles - 1] = null;
        NbRessourcesDisponibles--;
    }
}