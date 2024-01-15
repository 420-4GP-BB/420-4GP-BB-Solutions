using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


/**
 * Classe qui détermine la prochaine position avec la méthode Lerp de Vector3.
 *
 * Auteur: Éric Wenaas
 */

public class MouvementCubeVert : MonoBehaviour
{
    [SerializeField] private float vitesse; // La vitesse du joueur
    [SerializeField] private Collider colliderPlan;

    private Coroutine _deplacement; // On conserve une référence de la coroutine pour pouvoir l'arêter.

    // Start is called before the first frame update
    void Start()
    {
        _deplacement = StartCoroutine(DeplacerCube(transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = Utilitaires.DeterminerClic(colliderPlan);
            if (positionClic != null)
            {
                Vector3 positionFinale = new Vector3(transform.localPosition.x, transform.localPosition.y, positionClic.Value.z);
                StopCoroutine(_deplacement);
                _deplacement = StartCoroutine(DeplacerCube(positionFinale));
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
        yield return new WaitForEndOfFrame();
    }
}
