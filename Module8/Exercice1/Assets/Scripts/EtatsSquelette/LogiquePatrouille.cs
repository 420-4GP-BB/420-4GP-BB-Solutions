using UnityEngine;

public class LogiquePatrouille
{
    public Vector3 PointCourant
    {
        get
        {
            return points[_indicePatrouille].position;
        }
    }

    private Transform[] points;
    private int _indicePatrouille;

    public LogiquePatrouille(Transform[] points)
    {
        this.points = points;
        _indicePatrouille = 0;
    }

    public void PasserAuPointSuivant()
    {
        _indicePatrouille = (_indicePatrouille + 1) % points.Length;
    }
}
