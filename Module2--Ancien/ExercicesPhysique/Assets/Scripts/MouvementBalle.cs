using UnityEngine;

/// <summary>
/// Classe qui permet de déplacer la balle avec des forces
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class MouvementBalle : MonoBehaviour
{
    // La force de la balle
    [SerializeField]
    private float forceBalle;

    // Le Rigidbody de la balle
    private Rigidbody sphereRigidbody;

    // La valeur de la force a appliquer en horizontal
    private float forceHorizontal;

    // La valeur de la force a appliquer en vertical
    private float forceVertical;

    // La position initiale de la balle
    public Vector3 positionInitiale;

    // Start is called before the first frame update
    void Start()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
        positionInitiale = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        forceVertical = Input.GetAxis("Vertical");
        forceHorizontal = Input.GetAxis("Horizontal");

        // Pour l exercice 3
        if (transform.localPosition.y <= -2.0f)
        {
            ReplacerBalle();
        }
    }

    void FixedUpdate()
    {
        Vector3 directionForce = new Vector3(forceHorizontal, 0, forceVertical);
        Vector3 forceApplicable = directionForce * forceBalle;
        sphereRigidbody.AddForce(forceApplicable);
    }

    /**
     * Methode qui replace la balle au bon endroit
     *
     * Utilisee dans l exercice 3
     */
    public void ReplacerBalle()
    {
        sphereRigidbody.position = positionInitiale;
        sphereRigidbody.linearVelocity = Vector3.zero;
        sphereRigidbody.angularVelocity = Vector3.zero;
    }
}