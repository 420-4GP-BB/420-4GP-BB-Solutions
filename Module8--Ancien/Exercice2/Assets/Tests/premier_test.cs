using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class premier_test
{
    // A Test behaves as an ordinary method
    [Test]
    public void premier_testSimplePasses()
    {
        GameObject nouvelObjet = new GameObject();
        Assert.IsNotNull(nouvelObjet);
    }

}
