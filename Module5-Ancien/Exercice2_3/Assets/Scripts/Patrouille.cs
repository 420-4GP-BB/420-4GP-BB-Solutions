using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe qui fait patrouiller les champignons
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class Patrouille : MonoBehaviour
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
    /// Les points de la patrouille
    /// </summary>
    [SerializeField] private Transform[] pointsPatrouille;

    /// <summary>
    /// Le prochain point à atteindre dans la patrouille
    /// </summary>
    private int prochainPoint;

    /// <summary>
    /// Le contrôleur d'animation du champignon
    /// </summary>
    private Animator controlleurAnimation;

    /// <summary>
    ///  La coroutine pour le déplacement du champignon
    /// </summary>
    private Coroutine routineDeplacement;

    private bool deplacementActif = false;

    private bool aller;

    void Start()
    {
        aller = true;
        prochainPoint = 0;
        controlleurAnimation = GetComponent<Animator>();
        // routineDeplacement = StartCoroutine(DeplacerChampignon(pointsPatrouille[prochainPoint]));
    }

    // Update is called once per frame
    void Update()
    {
        if (! deplacementActif)
        {
            if (aller)
            {
                prochainPoint++;
            }
            else
            {
                prochainPoint--;
            }

            if (prochainPoint == pointsPatrouille.Length)
            {
                aller = false;
            }

            if (prochainPoint < 0)
            {
                aller = true;
            }
            if (prochainPoint >= 0 && prochainPoint < pointsPatrouille.Length)
            {
                StartCoroutine(DeplacerChampignon(pointsPatrouille[prochainPoint].position));
            }
        }        
    }

    /// <summary>
    /// Fonction qui fait tourner le champignon et ensuite le déplace vers la destination
    /// 
    /// </summary>
    /// <param name="destination">Le point de destination</param>
    /// <returns>IEnumerator car c'est une coroutine</returns>
    private IEnumerator DeplacerChampignon(Vector3 destination)
    {
        deplacementActif = true;
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

        deplacementActif = false;
        yield return new WaitForEndOfFrame();
    }
}
