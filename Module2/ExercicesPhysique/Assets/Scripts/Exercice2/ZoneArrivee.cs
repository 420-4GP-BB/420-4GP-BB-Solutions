using UnityEngine;
using TMPro;

/**
 * Classe qui donne et affiche des points quand la balle arrive dans la zone d arrivee
 * 
 * Auteur: Eric Wenaas
 */
public class ZoneArrivee : MonoBehaviour
{
    // La balle active. Quand elle tombe dans la zone, on ajoute un point
    [SerializeField]
    private GameObject balleActive;

    // Pour indiquer le nombre de points
    [SerializeField]
    private TMP_Text textZonePoints;

    // La position de depart d une nouvelle balle
    [SerializeField]
    private Vector3 positionDepart;

    // Les points. Le joueur obtient un point a chaque fois qu il envoie une balle dans la zone
    private int points;

    void Start()
    {
        points = 0;
        textZonePoints.text = "0";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == balleActive)
        {
            points++;
            textZonePoints.text = points.ToString();
            DupliquerBalle();
        }
    }

    /**
     * Copie la balle initiale
     * Elle ne doit plus repondre aux entrees de l utilisateur
     */
    private void DupliquerBalle()
    {
        GameObject nouvelleBalleActive = Instantiate(balleActive, positionDepart, Quaternion.identity);

        Destroy(balleActive.GetComponent<MouvementBalle>());

        balleActive = nouvelleBalleActive;
    }
}
