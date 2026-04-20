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
        GameObject prefabVillageois = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Villageois.prefab");
        // Il n y a pas de NavMesh dans notre scene
        prefabVillageois.GetComponent<NavMeshAgent>().enabled = false;

        villageois = GameObject.Instantiate(prefabVillageois, new Vector3(0, 0, 0), Quaternion.identity);

        // Charge les prefabs **SANS** les instancier tout de suite
        // Chaque test va decider quoi faire avec ca
        prefabOr = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Or.prefab");
        prefabPiege = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Piege.prefab");

        GameObject gameManagerObject = new GameObject();
        gameManager = gameManagerObject.AddComponent<GameManager>();
    }

    [TearDown]
    public void DetruireObjets()
    {
        GameObject.DestroyImmediate(villageois);

        // Detruire toutes les ressources et tous les pieges,
        // peu importe ce qu on a cree pendant le test
        foreach (Ressource ressource in gameManager.ressources)
            GameObject.DestroyImmediate(ressource.gameObject);
    }

    [UnityTest]
    public IEnumerator ObjectifPlusGrandeValeur_Simple()
    {
        // ARRANGE
        var or1 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 10), Quaternion.identity);
        var or2 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 0), Quaternion.identity);
        var or3 = GameObject.Instantiate(prefabOr, new Vector3(0, 0, 10), Quaternion.identity);
        var or4 = GameObject.Instantiate(prefabOr, new Vector3(5, 0, 5), Quaternion.identity);

        or1.GetComponent<Ressource>().valeur = 10;
        or2.GetComponent<Ressource>().valeur = 20;
        or3.GetComponent<Ressource>().valeur = 30;
        or4.GetComponent<Ressource>().valeur = 15;

        // ACT
        // Faire passer une frame : le villageois se fait appeller son Update()
        yield return null;

        var objectif = villageois.GetComponent<Villageois>().Objectif;

        // ASSERT
        Assert.AreSame(or3, objectif);
    }

    [UnityTest]
    public IEnumerator ObjectifPlusGrandeValeur_PlusRien()
    {
        // ARRANGE: Il n'y a aucune ressource d'or sur le jeu
        // (Le reste du ARRANGE est fait dans la méthode SetUp)

        // Faire passer une frame : valide que le villageois appelle son
        // Update() avant de continuer le test
        yield return null;

        var objectif = villageois.GetComponent<Villageois>().Objectif;

        Assert.IsTrue(objectif == null);
    }
}
