using System;
using System.Collections;
using UnityEngine;

public class DeplacementPersonnageCoroutineExercice7 : MonoBehaviour
{
    [SerializeField] private GameObject terrain;

    private Coroutine coroutineDeplacement;
    private Coroutine coroutineRotation;
    private Vector3 objectif;
    [SerializeField] private float vitesse = 5.0f;
    [SerializeField] private float vitesseRotation = 180.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var position = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(position);

            var hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject == terrain)
                {
                    if (coroutineDeplacement != null)
                    {
                        StopCoroutine(coroutineDeplacement);
                        StopCoroutine(coroutineRotation);
                    }

                    objectif = hit.point;
                    coroutineDeplacement = StartCoroutine(Deplacement());
                    coroutineRotation = StartCoroutine(Rotation());
                    break;
                }
            }
        }
    }

    IEnumerator Rotation()
    {
        // Trouver la direction
        var direction = (objectif - transform.position).normalized;

        var rotationFinale = Quaternion.LookRotation(direction);

        while (transform.rotation != rotationFinale)
        {
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, rotationFinale, vitesseRotation * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Deplacement()
    {
        // Trouver la direction
        var direction = (objectif - transform.position).normalized;

        // Tant que la distance est un peu trop grosse, on avance avec la formule de d�placement � la main
        while (Vector3.Distance(transform.position, objectif) > 0.5f)
        {
            transform.position += vitesse * Time.deltaTime * direction;
            yield return new WaitForEndOfFrame();
        }
    }
}