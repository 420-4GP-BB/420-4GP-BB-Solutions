using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class mouvement_ennemi
{

    [UnityTest]
    [Ignore("Ne passe pas car il faut un NavMesh")]
    public IEnumerator etat_initial_est_patrouille()
    {
        // ARRANGE
        GameObject ennemi = new GameObject();
        MouvementEnnemi mouvement = ennemi.AddComponent<MouvementEnnemi>();
        ennemi.AddComponent<Animator>();
        ennemi.AddComponent<NavMeshAgent>();

        mouvement.Construct(CreerPoints());

        // ACT
        yield return null;

        // ASSERT
        Assert.IsInstanceOf(typeof(EtatPatrouille), mouvement.EtatCourant);
    }


    private Transform[] CreerPoints()
    {
        Transform[] tabPoints = new Transform[4];
        for (int i = 0; i < tabPoints.Length; i++)
        {
            tabPoints[i] = new GameObject().transform;
        }

        tabPoints[0].position = Vector3.zero;
        tabPoints[1].position = Vector3.up;
        tabPoints[2].position = Vector3.down;
        tabPoints[3].position = Vector3.one;

        return tabPoints;
    }
}
