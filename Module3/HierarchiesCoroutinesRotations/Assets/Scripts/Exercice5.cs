using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// Script qui bouge le personnage graduellement et rotate immediatement
public class Exercice5 : MonoBehaviour
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
                    if (coroutine != null) StopCoroutine(coroutine);

                    objectif = hit.point;

                    Vector3 direction = (objectif - transform.position).normalized;
                    coroutine = StartCoroutine(DeplacerPersonnage(direction));
                }
            }
        }
    }

    private IEnumerator DeplacerPersonnage(Vector3 direction)
    {
        // Applique une rotation pour regarder l objectif
        transform.LookAt(objectif);

        while ((transform.position - objectif).magnitude > 0.5f)
        {
            transform.position += vitesseDeplacement * direction * Time.deltaTime;
            yield return null;
        }
    }
}