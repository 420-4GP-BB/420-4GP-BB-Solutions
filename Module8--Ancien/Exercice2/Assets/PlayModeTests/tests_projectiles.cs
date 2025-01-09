using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class tests_projectiles
{
    private GameObject _ennemi;
    private GameObject _projectile;

    public void Setup()
    {
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator test_degats()
    {
        // ARRANGE
        CreerObjets();

        // Ça ou mettre un if (_barreDeVie != null) dans PointsDeVie. Faites ce que vous trouverez le moins laid.
        _ennemi.GetComponent<PointsDeVie>().AjouterBarreVie(new GameObject().AddComponent<UnityEngine.UI.Slider>());

        PointsDeVie _ennemiPointsVie = _ennemi.GetComponent<PointsDeVie>();
        _ennemi.transform.position = new Vector3(2, 0, 0);
        _ennemi.transform.localScale = new Vector3(1, 1, 1);
        _ennemiPointsVie.SetPointsVieMax(3);

        _projectile.transform.position = new Vector3(0, 0, 0);
        _projectile.transform.localScale = new Vector3(1, 1, 1);
        _projectile.GetComponent<Projectile>().Dommages = 1;

        // ACT
        _projectile.transform.position = new Vector3(2, 0, 0);
        yield return new WaitForFixedUpdate();

        // ASSERT
        Assert.AreEqual(2, _ennemiPointsVie.PointsDeVieActuels);

        yield return null;
    }

    private void CreerObjets()
    {
        _projectile = new GameObject();
        _projectile.AddComponent<Rigidbody>();
        _projectile.AddComponent<SphereCollider>();
        _projectile.GetComponent<Collider>().isTrigger = true;
        _projectile.AddComponent<Projectile>();

        _ennemi = new GameObject();
        _ennemi.AddComponent<PointsDeVie>();
        _ennemi.AddComponent<Rigidbody>();
        _ennemi.AddComponent<CapsuleCollider>();

        // Ça ou mettre un if (_barreDeVie != null) dans PointsDeVie. Faites ce que vous trouvez le moins laid.
        _ennemi.GetComponent<PointsDeVie>().AjouterBarreVie(new GameObject().AddComponent<UnityEngine.UI.Slider>());
    }
}
