using System.Collections;
using UnityEngine;


/**
 * Classe qui déplace le joueur en utilisant la méthode Translate du composant Transform.
 * 
 * Fonctionne mal si la vitesse est trop grande. Ce sera corrigé en utilisant la méthode Lerp
 * dans le prochain exercice.
 *
 * Auteur: Éric Wenaas
 */

public class MouvementTranslate : MonoBehaviour
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
        yield return null;
    }
}
