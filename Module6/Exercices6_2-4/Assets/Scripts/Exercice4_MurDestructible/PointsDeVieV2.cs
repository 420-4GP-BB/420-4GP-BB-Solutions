using UnityEngine;
using UnityEngine.UI;

// Interface IBrisable pour comportement
// Ce script serait utilise pour le mur autant que pour les squelettes
public class PointsDeVieV2 : MonoBehaviour
{
    [SerializeField]
    private Slider barreDeVie;

    private int pointsDeVieMax = 3;
    private int pointsDeVieCourant = 3;

    void Start()
    {
        pointsDeVieCourant = pointsDeVieMax;
        barreDeVie.value = 1f;
    }

    void Update()
    {
        barreDeVie.transform.LookAt(Camera.main.transform);
    }   

    public void RetirerPointsDeVie(int dommages)
    {
        pointsDeVieCourant -= dommages;
        barreDeVie.value = (float) pointsDeVieCourant / pointsDeVieMax;

        if (pointsDeVieCourant <= 0)
        {
            IBrisable brisable = GetComponent<IBrisable>();
            brisable.Detruire();
        }
    }
}
