using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionnaireJeu : MonoBehaviour
{
    [SerializeField] private GameObject balle;
    [SerializeField] private Text champPoints;
    [SerializeField] private ZoneArrivee zone;
    [SerializeField] private Projection projection;

    private Vector3 _positionDepart;
    private int _points;

    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
        champPoints.text = _points.ToString();
//        zone.ZoneAtteinteHandler += AugmenterPoints;
        _positionDepart = balle.transform.localPosition;
    }

    private void AugmenterPoints()
    {
        _points++;
        champPoints.text = _points.ToString();

        GameObject nouvelleBalle = GameObject.Instantiate(balle);
        balle.transform.localPosition = _positionDepart;
        Rigidbody rb = balle.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Destroy(nouvelleBalle.GetComponent<MouvementBalle>());
    }
}
