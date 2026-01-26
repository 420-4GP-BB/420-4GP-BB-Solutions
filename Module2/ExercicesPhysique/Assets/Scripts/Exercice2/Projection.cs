using UnityEngine;

/**
 * Cette classe sert a projeter la balle quand elle arrive dans la zone
 *
 * Auteur : Eric Wenaas
 */
public class Projection : MonoBehaviour
{
    // La force de projection
    [SerializeField]
    private float forceProjection;

    // La direction de la projection
    [SerializeField]
    private Vector3 directionProjection;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        // Impulse : la force est appliquee une seule fois, comme un petit coup sec
        rb.AddForce(Vector3.up * forceProjection, ForceMode.Impulse);
    }
}