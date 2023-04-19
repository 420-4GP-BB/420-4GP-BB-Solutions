using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class premier_test {
    // A Test behaves as an ordinary method
    [Test]
    public void test_trivial()
    {
        // ARRANGE
        GameObject gameObject = new GameObject();

        // ACT
        // ASSERT
        Assert.NotNull(gameObject);
    }
}
