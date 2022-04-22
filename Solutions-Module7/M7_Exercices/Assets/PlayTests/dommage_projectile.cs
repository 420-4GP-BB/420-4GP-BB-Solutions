using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class dommage_projectile
{

    [UnityTest]
    public IEnumerator collision_avec_projectile_cause_des_degats()
    {
        // ARRANGE
        GameObject monstre = new GameObject();
        PointDeVie pdv = monstre.AddComponent<PointDeVie>();
        pdv.Construct(3);

        BoxCollider collider = monstre.AddComponent<BoxCollider>();
        collider.size = new Vector3(1, 1, 1);

        GameObject projectile = new GameObject();
        projectile.AddComponent<Rigidbody>();
        DommageProjectile dommage = projectile.AddComponent<DommageProjectile>();
        dommage.Construct(1);

        SphereCollider sphereCollider = projectile.AddComponent<SphereCollider>();
        sphereCollider.radius = 1.0f;


        // ACT
        yield return null;
        monstre.transform.position = projectile.transform.position; 
        yield return new WaitForFixedUpdate();

        // ASSERT
        Assert.AreEqual(2, pdv.NombrePointsVie);
    }
}
