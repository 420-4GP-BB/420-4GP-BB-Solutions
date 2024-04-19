using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacerCube : MonoBehaviour
{
    [SerializeField] private float _vitesse = 1.0f;

    void Update()
    {
        float vertical = Input.GetAxis("Vertical") * _vitesse * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * _vitesse * Time.deltaTime;
        transform.Translate(horizontal, vertical, 0);
    }
}
