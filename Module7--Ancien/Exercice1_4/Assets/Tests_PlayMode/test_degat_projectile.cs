using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class test_degat_projectile
{
    private GameObject _projectile;
    private GameObject _ennemi;
    

    [SetUp]
    public void SetUp()
    {
    }


    [UnityTest]
    public IEnumerator test_degats()
    {

        // ARRANGE
        CreerObjets();
        PointsVie _ennemiPointsVie = _ennemi.GetComponent<PointsVie>();
        _ennemi.transform.position = new Vector3(2, 0, 0);
        _ennemi.transform.localScale = new Vector3(1, 1, 1);
        _ennemiPointsVie.SetPointsVieMax(3);
        
        Collider _projectileCollider = _projectile.GetComponent<Collider>();
        Dommage _projectileDommage = _projectile.GetComponent<Dommage>();
        _projectile.transform.position = new Vector3(0, 0, 0);
        _projectile.transform.localScale = new Vector3(1, 1, 1);
        _projectileDommage.SetDommage(1);


        // ACT
        _projectileDommage.transform.position = new Vector3(2, 0, 0);
        yield return new WaitForFixedUpdate();
        
        // ASSERT

        Assert.AreEqual(2, _ennemiPointsVie.PointsVies);
    }

    private void CreerObjets()
    {
        _projectile = new GameObject();
        _projectile.AddComponent<Dommage>();
        _projectile.AddComponent<Rigidbody>();
        _projectile.AddComponent<SphereCollider>();
        _projectile.GetComponent<Collider>().isTrigger = true;

        _ennemi = new GameObject();
        _ennemi.AddComponent<PointsVie>();
        _ennemi.AddComponent<Rigidbody>();
        _ennemi.AddComponent<CapsuleCollider>();
    }
}
