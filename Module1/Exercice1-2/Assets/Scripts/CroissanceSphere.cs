using UnityEngine;

/*
 * Classe qui fait grandir et diminuer une sph�re
 *
 * Auteur: Eric Wenaas
 */

public class CroissanceSphere : MonoBehaviour
{
    // Pour decider si on agrandit ou on diminue la taille de la sphere
    private bool agrandissementActif = true;

    // Le taux de croissance du vecteur
    // Si on change ces valeurs, on change la vitesse d accroissement
    // Sera fait autrement dans l exercice 2
    private Vector3 vecteurCroissance = new Vector3(0.01f, 0.01f, 0.01f);

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Magnitude initiale: " + transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        if (agrandissementActif)
        {
            transform.localScale += vecteurCroissance;
        }
        else
        {
            transform.localScale -= vecteurCroissance;
        }

        // On regarde s il faut agrandir ou diminuer la taille pour la prochaine iteration
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
