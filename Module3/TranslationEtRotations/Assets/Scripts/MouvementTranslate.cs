using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


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
            Vector3? positionClic = DeterminerClic();
            if (positionClic != null)
            {
                Vector3 positionFinale = new Vector3(positionClic.Value.x, transform.localPosition.y, positionClic.Value.z);
                StopCoroutine(_deplacement);
                _deplacement = StartCoroutine(DeplacerCube(positionFinale));
            }
        }
    }


    /**
     * Méthode qui vérifie si le clic est sur le plan. Si le clic est à l'extérieur
     * alors, on retourne null
     */
    private Vector3? DeterminerClic()
    {
        Vector3 positionSouris = Input.mousePosition;
        Vector3? pointClique = null;

        // Trouver le lien avec la caméra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet touché est le plan.
            if (hit.collider == colliderPlan)
            {
                // Le vecteur est initialise ici car le clic est sur le plan
                Vector3 position = hit.point;
                pointClique = new Vector3(position.x, position.y, position.z);
            }
        }
        return pointClique;
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
