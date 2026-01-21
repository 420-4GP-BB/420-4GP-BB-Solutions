using UnityEngine;

/*
 * Classe qui implemente une camera de type topdown
 *
 * Auteur: Eric Wenaas
 */
public class CameraTopDown : MonoBehaviour 
{
    // Le joueur que l on suit
    [SerializeField] 
    private GameObject joueur;

    // La hauteur de la camera
    [SerializeField] 
    private float hauteur;

    void Start() 
    {
        PlacerCamera();
    }

    void LateUpdate() 
    {
        PlacerCamera();
    }

    /**
     * Methode qui place la camera en fonction de la position du joueur
     */
    private void PlacerCamera()
    {
        float positionX = joueur.transform.position.x;
        float positionZ = joueur.transform.position.z;
        transform.localPosition = new Vector3(positionX, hauteur, positionZ);
    }
}
