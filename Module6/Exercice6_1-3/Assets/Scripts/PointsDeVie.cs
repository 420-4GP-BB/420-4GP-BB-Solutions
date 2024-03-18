using UnityEngine;
using UnityEngine.UI;

public class PointsDeVie : MonoBehaviour
{
    [SerializeField] private int _pointsDeVieMax;
    [SerializeField] private Slider _barreDeVie;
    [SerializeField] private AudioSource _sonProjectile;

    private int _pointsDeVie;

    // Start is called before the first frame update
    void Start()
    {
        _pointsDeVie = _pointsDeVieMax;   
    }

    // Update is called once per frame
    void Update()
    {
        _barreDeVie.value = (float)_pointsDeVie / _pointsDeVieMax;        
    }

    void LateUpdate()
    {
        _barreDeVie.transform.LookAt(Camera.main.transform);
    }

    public void RetirerPointsDeVie(int dommages)
    {
        _pointsDeVie -= dommages;
        if (_pointsDeVie <= 0)
        {
            // Sera amélioré dans l'exercice 4
            MouvementSquelette mourant = GetComponent<MouvementSquelette>();
            GetComponent<MouvementSquelette>().ChangerEtat(new EtatMort(mourant, null));
        }
    }

}
