using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


/**
 * Classe qui déplace un objet avec la méthode MovePosition de Rigidbody
 *
 * Auteur: Éric Wenaas
 */

public class MouvementCubeRouge : MonoBehaviour
{
    [SerializeField] private float vitesse; // La vitesse du joueur
    [SerializeField] private Vector3 destination; // Le point de destination
    [SerializeField] private Rigidbody _rbody;

    private Coroutine _deplacement; // On conserve une référence de la coroutine pour pouvoir l'arêter.

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
        _deplacement = StartCoroutine(DeplacerCube(destination));
    }

    // Update is called once per frame
    void Update()
    {
    }


    /**
     * Méthode qui déplace l'objet dans la direction de la position finale.
     * 
     * Doit être déclenché dans une coroutine.
     */
    private IEnumerator DeplacerCube(Vector3 positionFinale)
    {

        bool termine = false;
        while (!termine)
        {
            Vector3 positionActuelle = transform.position;
            float distance = Vector3.Distance(positionActuelle, positionFinale);

            if (distance >= 0.1f)
            {
                Vector3 direction = positionFinale - positionActuelle;
                direction = direction.normalized;
                Debug.Log(direction.ToString());
                Vector3 nouvellePosition = transform.position + (direction * vitesse * Time.fixedDeltaTime);

                if (Vector3.Distance(positionActuelle, nouvellePosition) > Vector3.Distance(positionActuelle, positionFinale))
                {
                    _rbody.MovePosition(positionFinale);
                }
                else
                {
                    _rbody.MovePosition(nouvellePosition);
                }

                yield return new WaitForFixedUpdate();
            }
            else
            {
                _rbody.MovePosition(positionFinale);
                termine = true;
            }
        }
        yield return null;
    }
}
