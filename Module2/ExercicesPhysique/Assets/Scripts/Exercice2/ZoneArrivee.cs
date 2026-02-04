using UnityEngine;
using TMPro;

// Classe met a jour les points quand la balle arrive dans la zone d arrivee
public class ZoneArrivee : MonoBehaviour
{
    [SerializeField]
    private GameObject balleActive;

    // GameObject UI qui presente le nombre de point
    [SerializeField]
    private TMP_Text textePoints;

    private Vector3 positionDepart;
    private int points = 0;

    void Start()
    {
        positionDepart = balleActive.transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == balleActive)
        {
            AugmenterPoints();
            DupliquerBalle();
        }
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

        // Enleve le script de mouvement l ancienne balle
        Destroy(balleActive.GetComponent<MouvementBalle>());

        balleActive = nouvelleBalleActive;
    }
}
