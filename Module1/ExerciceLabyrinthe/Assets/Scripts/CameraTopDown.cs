using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Classe qui impl�mente une cam�ra de type top-down.
 *
 * Auteur: �ric Wenaas
 */
public class CameraTopDown : MonoBehaviour {

    [SerializeField] private GameObject joueur; // Le joueur que l'on suit
    [SerializeField] private float hauteur; // La hauteur de la cam�ra

    void Start() {
        PlacerCamera();
    }

    void LateUpdate() {
        PlacerCamera();
    }

    /**
     * M�thode qui place la cam�ra en fonction de la position du joueur
     */
    private void PlacerCamera()
    {
        float x = joueur.transform.position.x;
        float z = joueur.transform.position.z;
        transform.localPosition = new Vector3(x, hauteur, z);
    }
}
