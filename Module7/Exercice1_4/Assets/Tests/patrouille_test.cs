using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public class patrouille_test
{
    private LogiquePatrouille _patrouille;
    private Transform[] _transformsTest;

    private Vector3[] _points =
    {
        new Vector3(0, 0, 0),
        new Vector3(0, 0, 1),
        new Vector3(0, 0, 2),
        new Vector3(0, 0, 3)

    };

    [SetUp]
    public void Setup()
    {
        _transformsTest = new Transform[_points.Length];
        for (int i = 0; i < _points.Length; i++)
        {
            GameObject go = new GameObject();
            go.transform.position = _points[i];
            _transformsTest[i] = go.transform;
        }

        _patrouille = new LogiquePatrouille(_transformsTest);
    }

    [Test]
    // Test si on commence à l'indice 0
    public void test_patrouille_commence_au_debut()
    {
        // ARRANGE
        // ACT
        Vector3 point = _patrouille.PointCourant;
        // ASSERT
        Assert.AreEqual(_points[0], point);
    }

    [Test]
    // Test si on passe sur tous les points
    public void test_passe_tous_les_points()
    {
        // ARRANGE
        // ACT
        // ASSERT
        for (int i = 0; i < _points.Length; i++)
        {
            Vector3 point = _patrouille.PointCourant;
            Assert.AreEqual(_points[i], point);
            _patrouille.PasserAuPointSuivant();
        }
    }

    [Test]
    // Test si on revient au début après avoir passé tous les points
    public void test_patrouille_recommence_au_debut()
    {
        // ARRANGE
        // ACT
        for (int i = 0; i < _points.Length; i++)
        {
            _patrouille.PasserAuPointSuivant();
        }
        Vector3 point = _patrouille.PointCourant;
        
        // ASSERT
        Assert.AreEqual(_points[0], point);
    }
}
