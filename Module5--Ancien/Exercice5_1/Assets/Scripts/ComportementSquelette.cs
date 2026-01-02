using System.Collections;
using UnityEngine;

public class ComportementSquelette : MonoBehaviour
{
    [SerializeField] private Collider _colliderObjet;
    [SerializeField] private float _vitesse;
    [SerializeField] private float _vitesseRotation;

    private Animator _animator;
    private Coroutine _routineDeplacement;
    private Coroutine _routineRotation;


    // Start is called before the first fra
    //
    // me update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = Utilitaires.DeterminerClic(_colliderObjet);
            if (positionClic != null)
            {
                Vector3 positionFinale =
                    new Vector3(positionClic.Value.x, transform.localPosition.y, positionClic.Value.z);
                if (_routineDeplacement != null) StopCoroutine(_routineDeplacement);
                if (_routineRotation != null) StopCoroutine(_routineRotation);
                _routineDeplacement = StartCoroutine(Deplacement(positionFinale));
                _routineRotation = StartCoroutine(Rotation(positionFinale));
            }
        }

        // Si on a un KeyDown de la touche A pendant cette frame, on lance l'animation pour l'attaque
        bool attaqueRequise = Input.GetKeyDown(KeyCode.A);

        _animator.SetBool("Attack", attaqueRequise);
    }

    IEnumerator Rotation(Vector3 objectif)
    {
        // Trouver la direction
        var direction = (objectif - transform.position).normalized;

        var rotationFinale = Quaternion.LookRotation(direction);

        while (transform.rotation != rotationFinale)
        {
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, rotationFinale, _vitesseRotation * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Deplacement(Vector3 objectif)
    {
        _animator.SetBool("Walk", true);

        // Trouver la direction
        var direction = (objectif - transform.position).normalized;

        // Tant que la distance est un peu trop grosse, on avance avec la formule de déplacement à la main
        while (Vector3.Distance(transform.position, objectif) > 0.5f)
        {
            transform.position += _vitesse * Time.deltaTime * direction;
            yield return new WaitForEndOfFrame();
        }

        _animator.SetBool("Walk", false);
    }
}