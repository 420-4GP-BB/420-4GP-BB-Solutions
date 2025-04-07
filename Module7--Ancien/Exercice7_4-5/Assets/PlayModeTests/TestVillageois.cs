using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class TestVillageois
{
    private GameObject prefabOr, prefabPiege;

    private GameObject villageois;

    [SetUp]
    public void CreerObjets()
    {
        var prefabVillageois = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Villageois.prefab");
        // Il n'y a pas de NavMeshDans notre sc�ne
        prefabVillageois.GetComponent<NavMeshAgent>().enabled = false;

        villageois = GameObject.Instantiate(prefabVillageois, new Vector3(0, 0, 0), Quaternion.identity);

        // Charge les prefabs **SANS** les instancier tout de suite
        // Chaque test va d�cider quoi faire avec �a
        prefabOr = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Or.prefab");
        prefabPiege = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Piege.prefab");
    }

    [TearDown]
    public void DetruireObjets()
    {
        GameObject.DestroyImmediate(villageois);

        // D�truire toutes les ressources et tous les pi�ges,
        // peu importe ce qu'on a cr�� pendant le test
        foreach (var ressource in GameObject.FindObjectsOfType<Ressource>())
            GameObject.DestroyImmediate(ressource.gameObject);

        foreach (var piege in GameObject.FindObjectsOfType<Piege>())
            GameObject.DestroyImmediate(piege.gameObject);
    }

    [UnityTest]
    public IEnumerator ObjectifPlusGrandeValeur_Simple()
    {
        // ARRANGE
        var or1 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 10), Quaternion.identity);
        var or2 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 0), Quaternion.identity);
        var or3 = GameObject.Instantiate(prefabOr, new Vector3(0, 0, 10), Quaternion.identity);
        var or4 = GameObject.Instantiate(prefabOr, new Vector3(5, 0, 5), Quaternion.identity);

        or1.GetComponent<Ressource>().Valeur = 10;
        or2.GetComponent<Ressource>().Valeur = 20;
        or3.GetComponent<Ressource>().Valeur = 30;
        or4.GetComponent<Ressource>().Valeur = 15;

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
        // (Le reste du ARRANGE est fait dans la m�thode SetUp)

        // Faire passer une frame : valide que le villageois appelle son
        // Update() avant de continuer le test
        yield return null;

        var objectif = villageois.GetComponent<Villageois>().Objectif;

        Assert.IsTrue(objectif == null);
    }

    [UnityTest]
    public IEnumerator ObjectifPlusGrandeValeur_AvecNegatif()
    {
        // ARRANGE
        var or1 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 10), Quaternion.identity);
        var or2 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 0), Quaternion.identity);
        var or3 = GameObject.Instantiate(prefabOr, new Vector3(0, 0, 10), Quaternion.identity);
        var or4 = GameObject.Instantiate(prefabOr, new Vector3(5, 0, 5), Quaternion.identity);

        or1.GetComponent<Ressource>().Valeur = -10;
        or2.GetComponent<Ressource>().Valeur = 20;
        or3.GetComponent<Ressource>().Valeur = 30;
        or4.GetComponent<Ressource>().Valeur = -15;

        // ACT
        yield return null;

        var objectif = villageois.GetComponent<Villageois>().Objectif;

        Assert.AreSame(or3, objectif);
    }

    [UnityTest]
    public IEnumerator ObjectifPlusGrandeValeur_JamaisNegatif()
    {
        // ARRANGE
        var or1 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 10), Quaternion.identity);
        var or2 = GameObject.Instantiate(prefabOr, new Vector3(10, 0, 0), Quaternion.identity);
        var or3 = GameObject.Instantiate(prefabOr, new Vector3(0, 0, 10), Quaternion.identity);
        var or4 = GameObject.Instantiate(prefabOr, new Vector3(5, 0, 5), Quaternion.identity);

        or1.GetComponent<Ressource>().Valeur = -10;
        or2.GetComponent<Ressource>().Valeur = -20;
        or3.GetComponent<Ressource>().Valeur = -30;
        or4.GetComponent<Ressource>().Valeur = -15;

        // ACT
        yield return null;

        var objectif = villageois.GetComponent<Villageois>().Objectif;

        // ASSERT
        Assert.IsTrue(objectif == null);
    }

    [UnityTest]
    public IEnumerator CollisionPiegeEnleveOr()
    {
        // ARRANGE
        var piege = GameObject.Instantiate(prefabPiege, new Vector3(10, 0, 0), Quaternion.identity);
        villageois.GetComponent<Villageois>().Or = 50;

        // ACT
        yield return null;

        // D�place le villageois sur le pi�ge
        villageois.transform.position = new Vector3(10, 0, 0);

        // Attend qu'il y ait eu : une FixedUpdate() (pour que le moteur de physique passe et d�tecte les collisions)
        // ET une Update() normale (pour la logique de nos scripts)
        yield return null;
        yield return new WaitForFixedUpdate();

        int orFinal = villageois.GetComponent<Villageois>().Or;

        // ASSERT
        Assert.AreEqual(40, orFinal);

        // CORRECTION APPORT�E: La collision ne fonctionnait pas en raison de la configuration des objets
        // Le pi�ge �tait configur� en Trigger, sans Rigidbody, donc OnCollisionEnter() n'�tait jamais appel�
        // Pour r�gler �a, la configuration a plut�t �t� chang�e en : Rigidbody normal, Collider non-trigger
    }


    [UnityTest]
    public IEnumerator CollisionPiegeDetruit()
    {
        // ARRANGE
        var piege = GameObject.Instantiate(prefabPiege, new Vector3(10, 0, 0), Quaternion.identity);
        villageois.GetComponent<Villageois>().Or = 50;

        // ACT
        yield return null;

        // D�place le villageois sur le pi�ge
        villageois.transform.position = new Vector3(10, 0, 0);

        // Attend qu'il y ait eu : une FixedUpdate() (pour que le moteur de physique passe et d�tecte les collisions)
        // ET une Update() normale (pour la logique de nos scripts)
        yield return null;
        yield return new WaitForFixedUpdate();

        // ASSERT
        // Si le pi�ge a �t� d�truit, la variable teste true � == null
        Assert.IsTrue(piege == null);
    }
}