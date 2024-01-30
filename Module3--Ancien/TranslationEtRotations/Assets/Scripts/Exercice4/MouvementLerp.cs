using System.Collections;
using UnityEngine;


/**
 * Classe qui déplace le joueur en utilisant le composant Transform. On calcule
 * la nouvelle position avec la fonction Lerp.
 *
 * Auteur: Éric Wenaas
 */

public class MouvementLerp : MonoBehaviour
{
    [SerializeField] private float vitesse; // La vitesse du joueur
    [SerializeField] private Collider colliderPlan; // Le plancher pour la détection du clic

    private Coroutine _deplacement; // On conserve une référence de la coroutine pour pouvoir l'arêter.

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position.ToString());
        _deplacement = StartCoroutine(DeplacerCube(transform.localPosition));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = Utilitaires.DeterminerClic(colliderPlan);
            if (positionClic != null)
            {
                StopCoroutine(_deplacement);
                _deplacement = StartCoroutine(DeplacerCube(positionClic.Value));
            }
        }
    }

    /**
     * Méthode qui déplace l'objet dans la direction de la position finale.
     * 
     * Doit être déclenché dans une coroutine.
     */
    private IEnumerator DeplacerCube(Vector3 positionFinale)
    {
        float pourcentage = 0.0f; // Lerp fonctionne avec un pourcentage
        Vector3 positionDepart = transform.position;
        float distance = Vector3.Distance(positionFinale, positionDepart);

        while (pourcentage <= 1.0f)
        {
            pourcentage += Time.deltaTime * vitesse / distance;
            Vector3 nouvellePosition = Vector3.Lerp(positionDepart, positionFinale, pourcentage);
            transform.position = nouvellePosition;
            yield return new WaitForEndOfFrame();
        }
        transform.position = positionFinale;
        yield return new WaitForEndOfFrame();
    }
}
