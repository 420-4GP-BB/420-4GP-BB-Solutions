using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public class VueSouris : MonoBehaviour
{
    
    [SerializeField] private float angleMinimum;
    [SerializeField] private float angleMaximum;

    [SerializeField] private float sensibiliteX;
    [SerializeField] private float sensibiliteY;

    private  Vector2 _vueSouris;
    private Vector2 _douceur;
    GameObject _parent;

    private float _rotationX;
    private float _rotationY;
    
    // Start is called before the first frame update
    void Start()
    { 
        _parent = transform.parent.gameObject;
        _rotationX = 0;
        _rotationY = 0;
    }
    
    void Update()
    {
        if (GameManager.Instance().EnPause)
        {
            return;
        }

        _rotationX -= Input.GetAxis("Mouse Y") * sensibiliteY;
        _rotationX = Mathf.Clamp(_rotationX, angleMinimum, angleMaximum);
        _rotationY += Input.GetAxis("Mouse X") * sensibiliteX;
        transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
        _parent.transform.localEulerAngles  = new Vector3(0, _rotationY, 0);
    }
}

/*
 * Il existe plusieurs solutions possibles pour régler ce problème, celle présentée est probablement une des plus
 * simples. Voici un autre exemple, un peu plus complexe qui introduit un paramètre de douceur du déplacement
 * (smoothness) et de sensibilité de la souris
 */ 

