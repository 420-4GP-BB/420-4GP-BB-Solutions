using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Classe qui écoute la zone de jeu et met à jour les points.
 * 
 * Auteur: Éric Wenaas
 */

public class GestionnaireJeu : MonoBehaviour
{
    [SerializeField] private GameObject balle; // La balle
    [SerializeField] private Text champPoints; // Le champs de points qu'on doit mettre à jour
    [SerializeField] private ZoneArriveeSujet zone; // la zone d'arrivée qu'on observe
    
    private Vector3 _positionDepart;
    private int _points;

    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
        zone.ZoneAtteinteHandler += AugmenterPoints;
        _positionDepart = balle.transform.localPosition;
    }

    void OnGUI()
    {
        champPoints.text = _points.ToString();
    }


    /**
     * Méthode pour augmenter les points et pour créer une nouvelle balle
     */
    private void AugmenterPoints()
    {
        _points++;
        GameObject nouvelleBalle = GameObject.Instantiate(balle);
        nouvelleBalle.transform.localPosition = _positionDepart;
        zone.BalleActive = nouvelleBalle;
        Destroy(balle.GetComponent<MouvementBalle>());
        balle = nouvelleBalle;
    }
}
