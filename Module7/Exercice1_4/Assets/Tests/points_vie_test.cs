using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class points_vie_test
{
    private GameObject _gameObject;
    private PointsVie _pointsVie;

    [SetUp]
    public void Setup()
    {
        _gameObject = new GameObject();
        _pointsVie = _gameObject.AddComponent<PointsVie>();
        _gameObject.AddComponent<MurDetruit>();
        _pointsVie.SetPointsVieMax(3);
    }

    [Test]
    // Test si l'objet est détruit quand on atteint 0 points de vie
    public void test_objet_detruit()
    {
        // ARRANGE
        // ACT
        _pointsVie.RetirerPointsVie(3);

        // ASSERT
        Assert.IsTrue(_gameObject == null);
    }
}
