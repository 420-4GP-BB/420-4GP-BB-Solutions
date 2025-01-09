using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class test_points_vie
{
    private GameObject _gameObject;
    private PointsDeVie _pointsVie;

    [SetUp]
    public void Setup()
    {
        _gameObject = new GameObject();
        _pointsVie = _gameObject.AddComponent<PointsDeVie>();
        _gameObject.AddComponent<MurDetruit>();
        _pointsVie.SetPointsVieMax(3);
    }

    [Test]
    // Test si l'objet est détruit quand on atteint 0 points de vie
    public void test_objet_detruit()
    {
        // ARRANGE
        // ACT
        _pointsVie.RetirerPointsDeVie(3);

        // ASSERT
        Assert.IsTrue(_gameObject == null);
    }
}
