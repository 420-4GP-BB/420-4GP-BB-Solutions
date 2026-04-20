using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class TestVillageois
{
    private GameObject prefabOr;
    private GameObject prefabPiege;
    private GameObject villageois;

    private GameManager gameManager;

    [SetUp]
    public void CreerObjets()
    {
        // Instantiate un villageois
        GameObject prefabVillageois = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Villageois.prefab");
        villageois = GameObject.Instantiate(prefabVillageois, new Vector3(0, 0, 0), Quaternion.identity);
        villageois.GetComponent<NavMeshAgent>().enabled = false;

        // Charge les prefabs SANS les instancier tout de suite
        prefabOr = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Or.prefab");
        prefabPiege = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Piege.prefab");

        // Instantiate le game manager
        GameObject gameManagerObject = new GameObject();
        gameManager = gameManagerObject.AddComponent<GameManager>();
        gameManager.prefabOr = prefabOr;
        gameManager.prefabPiege = prefabPiege;
    }

    [TearDown]
    public void DetruireObjets()
    {
        // Detruire le villageois
        GameObject.DestroyImmediate(villageois);

        // Detruire toutes les ressources et tous les pieges
        foreach (Ressource ressource in gameManager.ressources)
        {
            GameObject.DestroyImmediate(ressource.gameObject);
        }
    }

    [UnityTest]
    public IEnumerator ObjectifPlusGrandeValeur_Simple()
    {
        // ARRANGE
        GameObject or1 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 10), Quaternion.identity);
        GameObject or2 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 0), Quaternion.identity);
        GameObject or3 = GameObject.Instantiate(prefabOr, new Vector3(0, 0, 10), Quaternion.identity);

        or1.GetComponent<Ressource>().valeur = 10;
        or2.GetComponent<Ressource>().valeur = 20;
        or3.GetComponent<Ressource>().valeur = 30;

        // ACT
        // Faire passer une frame : le villageois se fait appeller son Update()
        yield return null;

        GameObject objectif = villageois.GetComponent<Villageois>().objectif;

        // ASSERT
        Assert.AreSame(or3, objectif);
    }

    [UnityTest]
    public IEnumerator ObjectifPlusGrandeValeur_PlusRien()
    {
        // ARRANGE: Il n y a aucune ressource d or sur le jeu
        // (Le reste du ARRANGE est fait dans SetUp)

        // Faire passer une frame : valide que le villageois appelle son
        // Update() avant de continuer le test
        yield return null;

        GameObject objectif = villageois.GetComponent<Villageois>().objectif;

        Assert.IsTrue(objectif == null);
    }
}
