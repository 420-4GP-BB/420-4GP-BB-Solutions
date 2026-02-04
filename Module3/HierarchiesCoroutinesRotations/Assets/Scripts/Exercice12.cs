using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// Script qui rotate et deplace le personnage graduellement avec un rigidbody
public class Exercice12 : MonoBehaviour
{
    [SerializeField]
    private GameObject terrain;

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private float vitesseDeplacement = 2f;

    [SerializeField]
    private float vitesseRotation = 200f;

    private Rigidbody rigidbodyPersonnage;
    private Vector3 objectif;
    private Coroutine coroutineDeplacer;
    private Coroutine coroutineRotater;

    void Start()
    {
        rigidbodyPersonnage = GetComponent<Rigidbody>();
    }

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
                    ArreterCoroutines();

                    objectif = hit.point;

                    Vector3 direction = (objectif - rigidbodyPersonnage.position).normalized;
                    coroutineDeplacer = StartCoroutine(DeplacerPersonnage(direction));

                    Quaternion rotationFinale = Quaternion.LookRotation(direction);
                    coroutineRotater = StartCoroutine(RotaterPersonnage(rotationFinale));
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si je rentre en collision avec l obstacle
        if (collision.gameObject == obstacle)
        {
            ArreterCoroutines();
        }
    }

    private IEnumerator DeplacerPersonnage(Vector3 direction)
    {
        while ((rigidbodyPersonnage.position - objectif).magnitude > 0.5f)
        {
            rigidbodyPersonnage.position += vitesseDeplacement * direction * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator RotaterPersonnage(Quaternion rotationFinale)
    {
        while (Quaternion.Angle(rigidbodyPersonnage.rotation, rotationFinale) > 0.01f)
        {
            float rotationAppliquee = vitesseRotation * Time.deltaTime;
            rigidbodyPersonnage.rotation = Quaternion.RotateTowards(rigidbodyPersonnage.rotation, rotationFinale, rotationAppliquee);
            yield return null;
        }
    }

    // Methode qui arrete les couroutines de deplacement et de rotation
    private void ArreterCoroutines()
    {
        if (coroutineDeplacer != null) StopCoroutine(coroutineDeplacer);
        if (coroutineRotater != null) StopCoroutine(coroutineRotater);
    }
}