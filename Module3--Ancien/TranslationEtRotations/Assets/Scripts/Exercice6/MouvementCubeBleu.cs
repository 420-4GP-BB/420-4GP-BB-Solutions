using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


/**
 * Classe qui déplace le joueur en utilisant la méthode Translate du composant Transform.
 *
 * Auteur: Éric Wenaas
 */

public class MouvementCubeBleu : MonoBehaviour
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
        bool termine = false;
        while (!termine)
        {
            Vector3 positionActuelle = transform.position;
            float distance = Vector3.Distance(positionActuelle, positionFinale);

            if (distance >= 0.1f)
            {
                Vector3 direction = positionFinale - positionActuelle;
                direction = direction.normalized;
                transform.Translate(direction * vitesse * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            else
            {
                transform.position = positionFinale;
                termine = true;
            }
        }
        yield return new WaitForEndOfFrame();
    }
}
