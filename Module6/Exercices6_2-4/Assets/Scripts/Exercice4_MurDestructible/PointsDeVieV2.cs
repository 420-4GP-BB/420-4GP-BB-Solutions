using UnityEngine;
using UnityEngine.UI;

// Dans cette version, on va passer par l'interface IBrisable pour 
// déterminer ce qu'on fait lors du dernier coup donné
//
// Ce script serait utilisé pour le Mur brisable autant que pour les squelettes
public class PointsDeVieV2 : MonoBehaviour
{
    [SerializeField] private int _pointsDeVieMax;
    [SerializeField] private Slider _barreDeVie;

    private int _pointsDeVie;

    // Start is called before the first frame update
    void Start()
    {
        _pointsDeVie = _pointsDeVieMax;
        _barreDeVie.value = 1f;
    }

    void Update()
    {
        _barreDeVie.transform.LookAt(Camera.main.transform);
    }   

    public void RetirerPointsDeVie(int dommages)
    {
        _pointsDeVie -= dommages;
        _barreDeVie.value = (float)_pointsDeVie / _pointsDeVieMax;

        if (_pointsDeVie <= 0)
        {
            IBrisable brisable = GetComponent<IBrisable>();
            brisable.Detruire();
        }
    }
}
