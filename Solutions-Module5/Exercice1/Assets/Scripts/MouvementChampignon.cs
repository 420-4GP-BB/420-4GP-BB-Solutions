using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe qui démontre le fonctionnement des animations.
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class MouvementChampignon : MonoBehaviour
{
    /// <summary>
    /// La vitesse de mouvement
    /// </summary>
    [SerializeField] private float vitesseMouvement;

    /// <summary>
    /// La vitesse de rotation
    /// </summary>
    [SerializeField] private float vitesseRotation;

    /// <summary>
    /// Le collider de l'objet sur lequel on se déplace
    /// </summary>
    [SerializeField] private Collider colliderObjet;

    /// <summary>
    /// Le contrôleur d'animation du champignon
    /// </summary>
    private Animator controlleurAnimation;

    /// <summary>
    ///  La coroutine pour le déplacement du champignon
    /// </summary>
    private Coroutine routineDeplacement;

    void Start()
    {
        controlleurAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        // Si on clique, on peut avoir à déplacer le champignon
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = DeterminerClic(colliderObjet);
            if (positionClic != null)
            {
                Vector3 positionFinale = new Vector3(positionClic.Value.x, transform.localPosition.y, positionClic.Value.z);
                if (routineDeplacement != null)
                {
                    StopCoroutine(routineDeplacement);
                }
                routineDeplacement = StartCoroutine(DeplacerChampignon(positionFinale));
            }
        }

        // La lettre K tue le champignon
        if (Input.GetKey(KeyCode.K))
        {
            if (routineDeplacement != null)
            {
                StopCoroutine(routineDeplacement);
            }
            controlleurAnimation.SetBool("Dead", true);
        }
    }

    /// <summary>
    /// Détermine si la souris est sur le collider.
    /// </summary>
    /// <param name="collider">Le collider avec lequel on recherche le contact</param>
    /// <returns>Le point s'il y a un contact et null sinon</returns>
    private Vector3? DeterminerClic(Collider collideObjet)
    {
        Vector3 positionSouris = Input.mousePosition;
        Vector3? pointClique = null;

        // Trouver le lien avec la caméra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet touché est le plan.
            if (hit.collider == collideObjet)
            {
                // Le vecteur est initialise ici car le clic est sur le plan
                Vector3 position = hit.point;
                pointClique = new Vector3(position.x, position.y, position.z);
            }
        }
        return pointClique;
    }

    /// <summary>
    /// Fonction qui fait tourner le champignon et ensuite le déplacer.
    /// 
    /// </summary>
    /// <param name="destination">Le point de destination</param>
    /// <returns>IEnumerator car c'est une coroutine</returns>
    private IEnumerator DeplacerChampignon(Vector3 destination)
    {
        // La rotation
        Vector3 directionRotation = Vector3.Normalize(destination - transform.position);
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
        controlleurAnimation.SetBool("Run", true);
        yield return new WaitForEndOfFrame();

        float pourcentageMouvement = 0.0f; // Lerp fonctionne avec un pourcentage
        Vector3 positionDepart = transform.position;
        float distance = Vector3.Distance(destination, positionDepart);

        while (pourcentageMouvement <= 1.0f)
        {
            pourcentageMouvement += Time.deltaTime * vitesseMouvement / distance;
            Vector3 nouvellePosition = Vector3.Lerp(positionDepart, destination, pourcentageMouvement);
            transform.position = nouvellePosition;
            yield return new WaitForEndOfFrame();
        }
        controlleurAnimation.SetBool("Run", false);
        yield return new WaitForEndOfFrame();
    }
}

