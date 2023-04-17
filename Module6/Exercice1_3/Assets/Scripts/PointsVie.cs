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
            MouvementSquelette squelette = GetComponent<MouvementSquelette>();
            squelette.ChangerEtat(squelette.Mort);
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
