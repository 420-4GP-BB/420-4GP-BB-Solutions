using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{
    [SerializeField] private int nbOr;
    [SerializeField] private GameObject prefabOr;

    void Start()
    {
        for (int i = 0; i < nbOr; i++)
        {
            CreerOr();
        }
    }

    public GameObject CreerOr()
    {
        var position = new Vector3(
            Random.Range(-25f, +25f),
            0.5f,
            Random.Range(-25f, +25f)
        );
        var or = Instantiate(prefabOr, position, Quaternion.identity);

        int valeur = Random.Range(1, 30);
            
        // Faux or: valeur négative
        if (Random.value < 0.05f)
        {
            valeur = -15;
        }
            
        or.GetComponent<Ressource>().Valeur = valeur;

        return or;
    }
}