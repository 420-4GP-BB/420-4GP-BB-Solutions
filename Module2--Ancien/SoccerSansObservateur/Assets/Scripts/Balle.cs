using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody _rb;
    private Vector3 positionDepart;

    private int pointsBleu = 0;
    private int pointsRouge = 0;

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
        string nomParent = other.transform.parent.name;
        if (other.name == "Trigger" && nomParent == "ButRouge")
        {
            pointsBleu++;
            PointCompte();
        }
        else if (other.name == "Trigger" && nomParent == "ButBleu")
        {
            pointsRouge++;
            PointCompte();
        }
    }

    private void PointCompte()
    {
        Debug.Log("POINT! Bleus: " + pointsBleu + " || Rouges: " + pointsRouge);
        RemiseAZero();
    }

    private void RemiseAZero()
    {
        _rb.position = positionDepart;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}
