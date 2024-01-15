using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class test_degat_dans_scene
{

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Labyrinthe");
    }

    [UnityTest]
    public IEnumerator test_degat_projectile()
    {
        // ARRANGE
        GameObject prefabProjectile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Projectile.prefab");
        GameObject squelette = GameObject.Find("Squelette (0)");
        GameObject projectile = GameObject.Instantiate(prefabProjectile);

        // ACT
        // Génère la collision
        projectile.transform.position = squelette.transform.position;
        yield return new WaitForFixedUpdate();

        // ASSERT
        Assert.AreEqual(2, squelette.GetComponent<PointsVie>().PointsVies);
    }
}
