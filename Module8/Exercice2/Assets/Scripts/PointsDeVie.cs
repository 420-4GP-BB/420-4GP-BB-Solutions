using UnityEngine;
using UnityEngine.UI;

public class PointsDeVie : MonoBehaviour
{
    [SerializeField] private int _pointsDeVieMax;
    [SerializeField] private bool _doitRegarderLaCamera;

    private Slider _barreDeVie;

    [HideInInspector]
    [SerializeField]
    private int _pointsDeVie;


#if UNITY_EDITOR
    public void SetPointsVieMax(int pointsVieMax)
    {
        _pointsDeVieMax = pointsVieMax;
    }

    public int PointsDeVieActuels
    {
        get { return _pointsDeVie; }
    }

    public void AjouterBarreVie(Slider barreDeVie)
    {
        _barreDeVie = barreDeVie;
    }
#endif


    void Awake()
    {
        _barreDeVie = GetComponentInChildren<Slider>();
        _pointsDeVie = _pointsDeVieMax;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _barreDeVie.value = (float)_pointsDeVie / _pointsDeVieMax;        
    }

    void LateUpdate()
    {
        if (_doitRegarderLaCamera)
        {
            _barreDeVie.transform.LookAt(Camera.main.transform);
        }
    }

    public void RetirerPointsDeVie(int dommages)
    {
        _pointsDeVie -= dommages;
        if (_pointsDeVie <= 0)
        {
            IMortel mortel = GetComponent<IMortel>();
            if (mortel != null)
            {
                mortel.Mourir();
            }
        }
    }

}
