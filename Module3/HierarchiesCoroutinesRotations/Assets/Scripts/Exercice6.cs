using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// Script qui rotate et ensuite deplace le personnage graduellement
public class Exercice6 : MonoBehaviour
{
    [SerializeField]
    private GameObject terrain;

    [SerializeField]
    private float vitesseDeplacement = 5f;

    [SerializeField]
    private float vitesseRotation = 100f;

    private Vector3 objectif;
    private Coroutine coroutine;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 positionSouris = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(positionSouris);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == terrain)
                {
                    if (coroutine != null) StopCoroutine(coroutine);

                    objectif = hit.point;

                    Vector3 direction = (objectif - transform.position).normalized;
                    coroutine = StartCoroutine(DeplacerRotaterPersonnage(direction));
                }
            }
        }
    }

    private IEnumerator DeplacerRotaterPersonnage(Vector3 direction)
    {
        // Calcule la rotation finale du personnage
        Quaternion rotationFinale = Quaternion.LookRotation(direction);

        // Tant que l angle entre rotation actuelle et finale est grande
        while (Quaternion.Angle(transform.rotation, rotationFinale) > 0.01f)
        {
            // Calcule la rotation a appliquee
            float rotationAppliquee = vitesseRotation * Time.deltaTime;

            // Applique la rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationFinale, rotationAppliquee);

            // Attend le prochain frame avant de continuer
            yield return null;
        }

        // Le temps ecoule depuis le debut de la coroutine
        float tempsEcoule = 0f;
        while (tempsEcoule < 0.5f)
        {
            // Ajoute le temps ecoule depuis le dernier frame
            tempsEcoule += Time.deltaTime;

            // Attend le prochain frame avant de continuer
            yield return null;
        }

        while ((transform.position - objectif).magnitude > 0.5f)
        {
            transform.position += vitesseDeplacement * direction * Time.deltaTime;
            yield return null;
        }
    }
}