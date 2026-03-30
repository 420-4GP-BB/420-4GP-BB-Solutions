using UnityEngine;
using UnityEngine.UI;

public class PointsDeVie : MonoBehaviour
{
    [SerializeField]
    private Slider barreDeVie;

    private int pointsDeVieMax = 3;
    private int pointsDeVieCourant = 3;

    void Start()
    {
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
            ComportementEnnemi comportementEnnemi = GetComponent<ComportementEnnemi>();
            comportementEnnemi.ChangerEtat(comportementEnnemi.etatMort);
        }
    }
}
