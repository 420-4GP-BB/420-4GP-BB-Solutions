using UnityEngine;
using UnityEngine.UI;

public class PointsDeVie : MonoBehaviour
{
    [SerializeField] private int _pointsDeVieMax;
    [SerializeField] private Slider _barreDeVie; // TODO

    private int _pointsDeVie;

    // Start is called before the first frame update
    void Start()
    {
        _pointsDeVie = _pointsDeVieMax;
        _barreDeVie.value = 1f; // TODO
    }

    void Update()
    {
        _barreDeVie.transform.LookAt(Camera.main.transform); // TODO
    }   

    public void RetirerPointsDeVie(int dommages)
    {
        _pointsDeVie -= dommages;
        _barreDeVie.value = (float)_pointsDeVie / _pointsDeVieMax;  // TODO

        if (_pointsDeVie <= 0)
        {
            ComportementEnnemi mourant = GetComponent<ComportementEnnemi>();
            GetComponent<ComportementEnnemi>().ChangerEtat(new EtatMort(mourant));
        }
    }
}
