using UnityEngine;
using TMPro;

// Classe qui observe la zone de jeu et met a jour les points
public class GestionnaireJeu : MonoBehaviour
{
    [SerializeField] 
    private GameObject balleActive;

    // Texte UI qui presente le nombre de point
    [SerializeField] 
    private TMP_Text textePoints;

    private Vector3 positionDepart;
    private int points = 0;

    // Zone d arrivee qu on observe
    [SerializeField]
    private ZoneArriveeSujet zone;

    void Start()
    {
        positionDepart = balleActive.transform.position;
        
        // OBSERVATEUR: Quand la zone est touchee, on peut lister differentes
        // methodes qui doivent etre appelees en les enregistrant comme ca
        zone.ZoneAtteinteHandler += AugmenterPoints;
        zone.ZoneAtteinteHandler += DupliquerBalle;
    }

    private void AugmenterPoints()
    {
        points++;
        textePoints.text = points.ToString();
    }

    private void DupliquerBalle()
    {
        // Creer une nouvelle balle
        GameObject nouvelleBalleActive = Instantiate(balleActive, positionDepart, Quaternion.identity);

        // Enleve le script de mouvement de l ancienne balle
        Destroy(balleActive.GetComponent<MouvementBalle>());

        balleActive = nouvelleBalleActive;
        zone.balleActive = nouvelleBalleActive;
    }
}
