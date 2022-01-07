using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public class VueSouris : MonoBehaviour
{

    [SerializeField] private float sensibilite;
    [SerializeField] private float angleMinimum;
    [SerializeField] private float angleMaximum;

    // Start is called before the first frame update

    private float _rotationY;
    private float _rotationX;

    void Start()
    {
        _rotationY = transform.parent.localEulerAngles.y;
        _rotationX = transform.localEulerAngles.x;
        transform.parent.eulerAngles = new Vector3(0, _rotationY, 0);
        transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation sur le joueur
        float x = Input.GetAxis("Mouse X") * sensibilite;
        _rotationY += x;
        transform.parent.eulerAngles = new Vector3(0, _rotationY, 0);

        // Rotation sur la caméra
        float y = Input.GetAxis("Mouse Y") * sensibilite;
        _rotationX -= y;
        _rotationX = Mathf.Clamp(_rotationX, angleMinimum, angleMaximum);
        transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
    }
}

