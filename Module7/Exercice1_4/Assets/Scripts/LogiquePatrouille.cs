using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LogiquePatrouille
{
    private Transform[] _points;
    private int _indexPoint;

    public Vector3 PointCourant
    {
        get
        {
            return _points[_indexPoint].position;
        }
    }
    
    public LogiquePatrouille(Transform[] points)
    {
        _points = points;
        _indexPoint = 0;
    }
    public void PasserAuPointSuivant()
    {
        _indexPoint = (_indexPoint + 1) % _points.Length;
    }
}
