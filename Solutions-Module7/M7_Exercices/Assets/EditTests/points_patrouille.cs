using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

public class points_patrouille
{
    [Test]
    public void patrouille_commence_a_indice_zero()
    {
        // ARRANGE
        Transform[] tabPoints = CreerPoints();
        PointsPatrouille points = new PointsPatrouille(tabPoints);

        // ACT
        Transform actuelle = points.Destination;

        // ASSERT
        Assert.AreEqual(tabPoints[0].position, actuelle.position);
    }

    [Test]
    public void destination_ne_defonce_pas_tableau()
    {
        // ARRANGE
        Transform[] tabPoints = CreerPoints();
        PointsPatrouille points = new PointsPatrouille(tabPoints);

        // ACT
        try
        {
            // On traverse le tableau dans les deux directions
            for (int i = 0; i < tabPoints.Length * 2; i++)
            {
                points.PasserAuProchain();
                Transform actuelle = points.Destination;
            }
        }
        catch (Exception ex)
        {
            Assert.Fail();
        }

        // ASSERT
        Assert.Pass();
    }


    private Transform[] CreerPoints()
    {
        Transform[] tabPoints = new Transform[4];
        for (int i = 0; i < tabPoints.Length; i++)
        {
            tabPoints[i] = new GameObject().transform;
        }

        tabPoints[0].position = Vector3.zero;
        tabPoints[1].position = Vector3.up;
        tabPoints[2].position = Vector3.down;
        tabPoints[3].position = Vector3.one;

        return tabPoints;
    }


}
