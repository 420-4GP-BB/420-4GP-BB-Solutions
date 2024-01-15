using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementSquelette : MonoBehaviour
{
    [SerializeField] private Collider _colliderObjet;
    [SerializeField] private float _vitesse;
    [SerializeField] private float _vitesseRotation;

    private bool attaqueRequise = false;
    private Animator _animator;
    private Coroutine routineDeplacement;
    private Coroutine routineRotation;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = DeterminerClic(_colliderObjet);
            if (positionClic != null)
            {
                Vector3 positionFinale = new Vector3(positionClic.Value.x, transform.localPosition.y, positionClic.Value.z);
                if (routineDeplacement != null)
                {
                    StopCoroutine(routineDeplacement);
                }
                if (routineRotation != null)
                {
                    StopCoroutine(routineRotation);
                }
                routineDeplacement = StartCoroutine(DeplacerSquelette(positionFinale));
                routineRotation = StartCoroutine(TournerSquelette(positionFinale));
            }
        }
        
        if (attaqueRequise)
        {
            // Pour ne pas attaquer deux fois de suite
            attaqueRequise = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            attaqueRequise = true;
        }

        _animator.SetBool("Attack", attaqueRequise);
    }

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

    private IEnumerator DeplacerSquelette(Vector3 destination)
    {
        _animator.SetBool("Walk", true);

        float pourcentageMouvement = 0.0f; // Lerp fonctionne avec un pourcentage
        Vector3 positionDepart = transform.position;
        float distance = Vector3.Distance(destination, positionDepart);

        while (pourcentageMouvement <= 1.0f)
        {
            pourcentageMouvement += Time.deltaTime * _vitesse / distance;
            Vector3 nouvellePosition = Vector3.Lerp(positionDepart, destination, pourcentageMouvement);
            transform.position = nouvellePosition;
            yield return new WaitForEndOfFrame();
        }
        _animator.SetBool("Walk", false);
        yield return new WaitForEndOfFrame();
    }

    private IEnumerator TournerSquelette(Vector3 destination)
    {
        Vector3 directionRotation = Vector3.Normalize(destination - transform.position);
        Quaternion rotationInitiale = transform.rotation;
        Quaternion rotationCible = Quaternion.LookRotation(directionRotation, Vector3.up);

        float pourcentageRotation = 0.0f;
        float angle = Quaternion.Angle(rotationInitiale, rotationCible);

        while (pourcentageRotation <= 1.0f)
        {
            pourcentageRotation += Time.deltaTime * _vitesseRotation / angle;
            Quaternion rotation = Quaternion.Slerp(rotationInitiale, rotationCible, pourcentageRotation);
            transform.rotation = rotation;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }
}
