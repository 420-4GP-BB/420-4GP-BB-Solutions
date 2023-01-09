using UnityEngine;
public class PointsPatrouille
{
    private Transform[] _pointsPatrouille;
    private int _indicePoints;
    private bool _versAvant;

    public Transform Destination
    {
        get { return _pointsPatrouille[_indicePoints];}
    }
 
    public PointsPatrouille(Transform[] lesPoints)
    {
        _pointsPatrouille = lesPoints;
        _indicePoints = 0;
        _versAvant = true;
    }

    public void PasserAuProchain()
    {
        if (_versAvant)
        {
            _indicePoints++;
        }
        else
        {
            _indicePoints--;
        }

        if (_indicePoints == _pointsPatrouille.Length)
        {
            _versAvant = false;
            _indicePoints = _indicePoints - 1;
        }

        if (_indicePoints < 0)
        {
            _versAvant = true;
            _indicePoints = 0;
        }
    }
}
