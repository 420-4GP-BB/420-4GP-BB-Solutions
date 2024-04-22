using System;
using UnityEngine;

[Serializable]
public class LogiquePatrouille
{
    public Vector3 PointCourant
    {
        get
        {
            return points[_indicePatrouille].position;
        }
    }

    public int IndicePatrouille
    {
        get => _indicePatrouille;
        set => _indicePatrouille = value;
    }

    private Transform[] points;

    [SerializeField]
    private int _indicePatrouille;

    public LogiquePatrouille(Transform[] points, int indice)
    {
        this.points = points;
        _indicePatrouille = indice;
    }

    public void PasserAuPointSuivant()
    {
        _indicePatrouille = (_indicePatrouille + 1) % points.Length;
    }
}
