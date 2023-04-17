using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsVie : MonoBehaviour
{
    [SerializeField] private int _pointsVieMax;
    [SerializeField] private Slider _sliderPV;
    private int _pointsVie;

    // Start is called before the first frame update
    void Start()
    {
        _pointsVie = _pointsVieMax;
    }

    public void RetirerPointsVie(int points)
    {
        _pointsVie -= points;
        if (_pointsVie <= 0)
        {
            IMortel mortel = GetComponent<IMortel>();
            if (mortel != null)
            {
                mortel.FaireMourir();
            }
        }
    }

    public void Update()
    {
        _sliderPV.transform.LookAt(Camera.main.transform);
    }

    public void OnGUI()
    {
        _sliderPV.value = (float)_pointsVie / _pointsVieMax;
    }
}
