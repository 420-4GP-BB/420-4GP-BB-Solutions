using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// Script qui bouge le personnage graduellement
public class Exercice4 : MonoBehaviour
{
    [SerializeField]
    private GameObject terrain;

    [SerializeField]
    private float vitesseDeplacement = 5f;

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
                    // Arreter l ancienne coroutine
                    if (coroutine != null) StopCoroutine(coroutine);

                    // Mettre a jour l objectif
                    objectif = hit.point;

                    // Calculer la direction de mouvement (normalise)
                    Vector3 direction = (objectif - transform.position).normalized;

                    // Debuter la coroutine de mouvement
                    coroutine = StartCoroutine(DeplacerPersonnage(direction));
                }
            }
        }
    }

    private IEnumerator DeplacerPersonnage(Vector3 direction)
    {
        // Tant que la distance entre personnage et objectif est grande
        while ((transform.position - objectif).magnitude > 0.5f)
        {
            // Deplace le personnage dans la direction de mouvement
            transform.position += vitesseDeplacement * direction * Time.deltaTime;

            // Attend le prochain frame avant de continuer
            yield return null;
        }
    }
}