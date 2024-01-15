using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/**
 * Classe qui illustre une rotation avec Slerp
 * 
 * Auteur: Éric Wenaas
 */

public class MouvementSlerp : MonoBehaviour
{
    [SerializeField] private float vitesse; // La vitesse du joueur
    [SerializeField] private float vitesseRotation; // La vitesse de rotation 
    [SerializeField] private Collider colliderPlan; // Le plancher pour la détection du clic

    private Coroutine _deplacement; // On conserve une référence de la coroutine pour pouvoir l'arêter.

    // Start is called before the first frame update
    void Start()
    {
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
        // La rotation

        Vector3 directionRotation = Vector3.Normalize(positionFinale - transform.position);
        Quaternion rotationInitiale = transform.rotation;
        Quaternion rotationCible = Quaternion.LookRotation(directionRotation, Vector3.up);
        float pourcentageRotation = 0.0f;
        float angle = Quaternion.Angle(rotationInitiale, rotationCible);

        while (pourcentageRotation <= 1.0f)
        {
            pourcentageRotation += Time.deltaTime * vitesseRotation / angle;
            Quaternion rotation = Quaternion.Slerp(rotationInitiale, rotationCible, pourcentageRotation);
            transform.rotation = rotation;
            yield return new WaitForEndOfFrame();
        }

        // Le déplacement
        float pourcentageMouvement = 0.0f; // Lerp fonctionne avec un pourcentage
        Vector3 positionDepart = transform.position;
        float distance = Vector3.Distance(positionFinale, positionDepart);

        while (pourcentageMouvement <= 1.0f)
        {
            pourcentageMouvement += Time.deltaTime * vitesse / distance;
            Vector3 nouvellePosition = Vector3.Lerp(positionDepart, positionFinale, pourcentageMouvement);
            transform.position = nouvellePosition;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
    }

}
