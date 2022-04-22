using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class points_de_vie
{

    [UnityTest]
    public IEnumerator points_de_vie_tombe_a_zero_lance_evenement_zero_atteint()
    {
        bool evenementLance = false;

        // ARRANGE
        GameObject monstre = new GameObject();
        PointDeVie pdv = monstre.AddComponent<PointDeVie>();
        pdv.Construct(3);
        pdv.AtteintZeroHandler += delegate (GameObject obj)
        {
            evenementLance = true;
        };

        // ACT
        // Le start de l'objet sera appelé lors du premier yield return null
        yield return null;
        pdv.RetirerPointDeVie(1);

        yield return null;
        pdv.RetirerPointDeVie(1);

        yield return null;
        pdv.RetirerPointDeVie(1);

        // ASSERT
        Assert.AreEqual(true, evenementLance);
    }
}
