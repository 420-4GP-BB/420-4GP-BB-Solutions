﻿using UnityEngine;
using TMPro;

/**
 * Classe qui donne et affiche des points quand la balle arrive dans la zone d'arrivée
 * 
 * Auteur: Éric Wenaas
 */
public class ZoneArrivee : MonoBehaviour
{
    [SerializeField] private GameObject balleActive;   // La balle active. Quand elle tombe dans la zone, on ajoute un point
    [SerializeField] private TMP_Text txtZonePoints;       // Pour indiquer le nombre de points
    [SerializeField] private Vector3 positionDepart;   // La position de départ d'une nouvelle balle

    private int _points;   // Les points. Le joueur obtient un point à chaque fois qu'il envoie une balle dans la zone.

    void Start()
    {
        _points = 0;
        txtZonePoints.text = "0";
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == balleActive)
        {
            _points++;
            txtZonePoints.text = _points.ToString();
            balleActive = DupliquerBalle(balleActive);
            ReplacerBalle(balleActive);
        }
    }

    /**
     * Copie la balle initiale
     * Elle ne doit plus répondre aux entrées de l'utilisateur
     */
    private GameObject DupliquerBalle(GameObject balle)
    {
        GameObject nouvelle = GameObject.Instantiate(balle);
        Destroy(balleActive.GetComponent<MouvementBalle>());
        return nouvelle;        
    }

    /**
     * Replace la balle à son endroit intial
     */
    private void ReplacerBalle(GameObject balle)
    {
        MouvementBalle instanceMouvement = balle.GetComponent<MouvementBalle>();
        instanceMouvement.PositionInitiale = positionDepart;
        instanceMouvement.ReplacerBalle();
    }
}
