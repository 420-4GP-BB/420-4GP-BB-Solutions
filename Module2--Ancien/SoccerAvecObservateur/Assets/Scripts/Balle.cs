using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BalleCollision(Balle balle, Collider collider);

public class Balle : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody _rb;
    private Vector3 positionDepart;

    public event BalleCollision OnBalleDansFilet;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        positionDepart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemiseAZero();
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rb.AddForce(speed * new Vector3(0, 0, -1), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rb.AddForce(speed * new Vector3(0, 0, +1), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rb.AddForce(speed * new Vector3(-1, 0, 0), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rb.AddForce(speed * new Vector3(+1, 0, 0), ForceMode.Impulse);
        }

        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, speed * 2);

        if (transform.position.y < -5)
        {
            Debug.Log("Hors jeu");
            RemiseAZero();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Trigger")
        {
            // Tous les observateurs de l'événement se font
            // notifier du fait que la balle vient d'entrer dans le filet
            OnBalleDansFilet?.Invoke(this, other);
        }
    }

    public void RemiseAZero()
    {
        _rb.position = positionDepart;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}