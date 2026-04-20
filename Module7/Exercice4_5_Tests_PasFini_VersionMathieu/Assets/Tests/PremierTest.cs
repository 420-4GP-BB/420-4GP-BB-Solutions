using NUnit.Framework;
using UnityEngine;

public class PremierTest
{
    [Test]
    public void TrouverOrPlusPrecieux_Simple1()
    {
        // Arrange
        Ressource ressource1 = new GameObject().AddComponent<Ressource>();
        ressource1.valeur = 10;
        Ressource ressource2 = new GameObject().AddComponent<Ressource>();
        ressource2.valeur = 20;
        System.Collections.Generic.List<Ressource> ressources = new() { ressource1, ressource2 };

        GameObject gameManagerObject = new GameObject();
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();

        // Act
        int indexPrecieux = gameManager.TrouverOrPlusPrecieux(ressources);
        
        // Assert
        Assert.AreEqual(1, indexPrecieux);
    }

    [Test]
    public void TrouverOrPlusPrecieux_Simple2()
    {
        // Arrange
        Ressource ressource1 = new GameObject().AddComponent<Ressource>();
        ressource1.valeur = 10;
        System.Collections.Generic.List<Ressource> ressources = new() { ressource1 };

        GameObject gameManagerObject = new GameObject();
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();

        // Act
        int indexPrecieux = gameManager.TrouverOrPlusPrecieux(ressources);

        // Assert
        Assert.AreEqual(0, indexPrecieux);
    }

    [Test]
    public void TrouverOrPlusPrecieux_Limite1()
    {
        // Arrange
        Ressource ressource1 = new GameObject().AddComponent<Ressource>();
        System.Collections.Generic.List<Ressource> ressources = new() { ressource1 };

        GameObject gameManagerObject = new GameObject();
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();

        // Act
        int indexPrecieux = gameManager.TrouverOrPlusPrecieux(ressources);

        // Assert
        Assert.AreEqual(0, indexPrecieux);
    }

    [Test]
    public void TrouverOrPlusPrecieux_Limite2()
    {
        // Arrange
        System.Collections.Generic.List<Ressource> ressources = new() {  };

        GameObject gameManagerObject = new GameObject();
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();

        // Act
        int indexPrecieux = gameManager.TrouverOrPlusPrecieux(ressources);

        // Assert
        Assert.AreEqual(-1, indexPrecieux);
    }
}
