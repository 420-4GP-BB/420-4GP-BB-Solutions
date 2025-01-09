using System.Collections;
using UnityEngine;

public class ComportementSquelette : MonoBehaviour
{
    [SerializeField] private Collider _colliderObjet;
    [SerializeField] private float _vitesse;
    [SerializeField] private float _vitesseRotation;

    private Animator _animator;
    private Coroutine routineDeplacement;
    private Coroutine routineRotation;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        // Petit design pattern pratique de temps en temps: le Null Object (objet Null)
        // Pour éviter d'avoir des coroutines initialement à null (et donc devoir tester
        // si la coroutine est null ou pas avant de faire StopCoroutine() plus bas),
        // on lance une coroutine vide question de toujours en avoir une première
        routineDeplacement = StartCoroutine(Utilitaires.neRienFaire());
        routineRotation = StartCoroutine(Utilitaires.neRienFaire());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = Utilitaires.DeterminerClic(_colliderObjet);
            if (positionClic != null)
            {
                Vector3 positionFinale = new Vector3(positionClic.Value.x, transform.localPosition.y, positionClic.Value.z);
                StopCoroutine(routineDeplacement);
                StopCoroutine(routineRotation);
                routineDeplacement = StartCoroutine(DeplacerSquelette(positionFinale));
                routineRotation = StartCoroutine(TournerSquelette(positionFinale));
            }
        }

        // Si on a un KeyDown de la touche A pendant cette frame, on lance l'animation pour l'attaque
        bool attaqueRequise = Input.GetKeyDown(KeyCode.A);

        _animator.SetBool("Attack", attaqueRequise);
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
