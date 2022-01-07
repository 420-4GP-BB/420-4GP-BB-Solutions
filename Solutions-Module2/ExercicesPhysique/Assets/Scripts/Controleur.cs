using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controleur : MonoBehaviour
{
    [SerializeField] private GameObject balle;
    [SerializeField] private Text champPoints;
    [SerializeField] private ZoneArrivee zone;
    [SerializeField] private Projection projection;

    private Vector3 positionDepart;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        champPoints.text = "Points: " + points.ToString();
        zone.ZoneAtteinteHandler += AugmenterPoints;
        positionDepart = balle.transform.localPosition;
    }

    private void AugmenterPoints()
    {
        points++;
        champPoints.text = "Points: " + points.ToString();

        GameObject nouvelleBalle = GameObject.Instantiate(balle);
        balle.transform.localPosition = positionDepart;
        Rigidbody rb = balle.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Destroy(nouvelleBalle.GetComponent<MouvementBalle>());
    }
}
