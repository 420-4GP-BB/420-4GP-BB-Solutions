using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;

public class test_projectile_scene
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Labyrinthe");
    }

    [UnityTest]
    public IEnumerator test_projectile_dans_scene()
    {
        // ARRANGE
        GameObject prefabProjectile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Projectile.prefab");
        GameObject squelette = GameObject.Find("Squelette (0)");
        GameObject projectile = GameObject.Instantiate(prefabProjectile);

        // ACT
        projectile.transform.position = squelette.transform.position;
        yield return new WaitForFixedUpdate();

        // ASSERT
        Assert.AreEqual(2, squelette.GetComponent<PointsDeVie>().PointsDeVieActuels);    
    }
}
