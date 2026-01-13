using UnityEngine;

/*
 * Classe qui agrandit et diminue une sphere. Utilise une vitesse qui peut etre
 * configuree dans l inspecteur de Unity
 *
 * Auteur: Eric Wenaas
 */

public class CroissanceSphereVitesse : MonoBehaviour
{
    // Pour decider si on agrandit ou on diminue la taille de la sphere
    private bool agrandissementActif = true;

    // Le taux de croissance du vecteur
    private Vector3 vecteurCroissance = Vector3.one;

    // La vitesse de croissance/decroissance de la sphere
    [SerializeField] private float vitesse;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Magnitude initiale: " + transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 croissance = vitesse * Time.deltaTime * vecteurCroissance;

        if (agrandissementActif)
        {
            transform.localScale += croissance;
        }
        else
        {
            transform.localScale -= croissance;
        }

        // On regarde s il faut grandir ou diminuer pour la prochaine iteration
        if (transform.localScale.magnitude >= 8.0f)
        {
            agrandissementActif = false;
        }

        if (transform.localScale.magnitude <= 2.0f)
        {
            agrandissementActif = true;
        }
    }
}
