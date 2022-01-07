using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour {

    [SerializeField] private  Transform sujet;
    [SerializeField] private float hauteur;

    void Start() {
        transform.position = new Vector3(sujet.position.x, hauteur, sujet.position.z);
    }

    void LateUpdate() {
        transform.position = new Vector3(sujet.position.x, hauteur, sujet.position.z);
    }
}
