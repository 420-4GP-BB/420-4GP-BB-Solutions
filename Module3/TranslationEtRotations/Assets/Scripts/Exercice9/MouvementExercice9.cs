using System;
using System.Collections;
using UnityEngine;

/**
 * Classe qui fait le déplacement et la rotation en même temps.
 * 
 * Auteur: Éric Wenaas
 */

public class MouvementExercice9 : MonoBehaviour
{
    [SerializeField] private float vitesse; // La vitesse du joueur
    [SerializeField] private float vitesseRotation; // La vitesse de rotation 
    [SerializeField] private Collider colliderPlan; // Le plancher pour la détection du clic

    private Coroutine _deplacement; // La coroutine pour le déplacement
    private Coroutine _rotation;    // La coroutine pour la rotation

    // Start is called before the first frame update
    void Start()
    {
        _deplacement = StartCoroutine(DeplacerCube(transform.localPosition));
        _rotation = StartCoroutine(TournerCubeVers(transform.localPosition));
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
                StopCoroutine(_rotation);
                _rotation = StartCoroutine(TournerCubeVers(positionClic.Value));
            }
        }
    }

    /**
     * Méthode qui fait tourner l'objet dans la direction de la rotation finale.
     *  
     * Doit être déclenché dans une coroutine.
     */
    private IEnumerator TournerCubeVers(Vector3 positionFinale)
    {
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
        }    }

    /**
     * Méthode qui déplace l'objet dans la direction de la position finale.
     * 
     * Doit être déclenché dans une coroutine.
     */
    private IEnumerator DeplacerCube(Vector3 positionFinale)
    {
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
