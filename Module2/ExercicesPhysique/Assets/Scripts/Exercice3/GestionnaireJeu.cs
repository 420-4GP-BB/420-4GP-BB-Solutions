using UnityEngine;
using TMPro;

/**
 * Cette classe ecoute la zone de jeu et met a jour les points
 * 
 * Auteur: Eric Wenaas
 */
public class GestionnaireJeu : MonoBehaviour
{
    // La balle
    [SerializeField] 
    private GameObject balle;

    // Le champs de points qu on doit mettre a jour
    [SerializeField] 
    private TMP_Text champPoints;

    // la zone d arrivee qu on observe
    [SerializeField]
    private ZoneArriveeSujet zone;

    private Vector3 positionDepart;
    private int points;

    void Start()
    {
        points = 0;
        
        // OBSERVATEUR: Quand la zone est touchee, on peut lister differentes
        // methodes qui doivent etre appelees en les enregistrant comme ca
        zone.ZoneAtteinteHandler += AugmenterPoints;
        zone.ZoneAtteinteHandler += ReplacerBalle;
        
        positionDepart = balle.transform.localPosition;
        champPoints.text = points.ToString();
    }

    // Methode pour augmenter les points
    private void AugmenterPoints()
    {
        points++;
        champPoints.text = points.ToString();
    }

    // Methode pour creer une nouvelle balle
    private void ReplacerBalle()
    {
        GameObject nouvelleBalle = Instantiate(balle, positionDepart, Quaternion.identity);
        
        Destroy(balle.GetComponent<MouvementBalle>());

        zone.balleActive = nouvelleBalle;
        balle = nouvelleBalle;
    }
}
