using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementRotation : MonoBehaviour
{
    [SerializeField] private float vitesse; // La vitesse du joueur
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
        Vector3 directionRotation = Vector3.Normalize(positionFinale - transform.position);
        Quaternion rotation = Quaternion.LookRotation(directionRotation, Vector3.up);
        transform.rotation = rotation;

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
