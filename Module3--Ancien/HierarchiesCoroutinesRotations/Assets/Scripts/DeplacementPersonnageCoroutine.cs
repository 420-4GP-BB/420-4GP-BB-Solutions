using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementPersonnageCoroutine : MonoBehaviour
{
    [SerializeField] private GameObject terrain;

    private Coroutine coroutineDeplacement;
    private Vector3 objectif;
    [SerializeField] private float vitesse = 5.0f;
    [SerializeField] private float vitesseRotation = 180.0f;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            var position = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(position);

            var hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject == terrain)
                {
                    if (coroutineDeplacement != null)
                        StopCoroutine(coroutineDeplacement);

                    objectif = hit.point;
                    coroutineDeplacement = StartCoroutine(Deplacement());
                    break;
                }
            }
        }
    }

    IEnumerator Deplacement()
    {
        // Exercice 5: on donne directement la position à regarder à LookAt()
        // transform.LookAt(objectif);
        
        // Trouver la direction
        var direction = (objectif - transform.position).normalized;


        // Exercice 6: on considère la *direction* dans laquelle regarder
        var rotationFinale = Quaternion.LookRotation(direction);
        
        while (transform.rotation != rotationFinale)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationFinale, vitesseRotation * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        
        yield return new WaitForSeconds(0.5f);
        
        // Exercice 4:
        // Tant que la distance est un peu trop grosse, on avance avec la formule de déplacement à la main
        while (Vector3.Distance(transform.position, objectif) > 0.5f)
        {
            transform.position += vitesse * Time.deltaTime * direction;
            yield return new WaitForEndOfFrame();
        }
    }
}