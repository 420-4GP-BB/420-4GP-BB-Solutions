using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TestUtilitaires{
    // Classe pour tester les methodes sur IPrecieux
    public class TestPrecieux : IPrecieux { public int Valeur { get; set; } }

    [Test]
    public void TrouverPlusPrecieux_Simple1()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = 10 },
            new TestPrecieux { Valeur = 50 },
            new TestPrecieux { Valeur = 20 }
        };

        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);

        // Assert
        Assert.AreEqual(50, plusPrecieux.Valeur);
    }

    [Test]
    public void TrouverPlusPrecieux_Simple2()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = 10 },
            new TestPrecieux { Valeur = 15 },
            new TestPrecieux { Valeur = 20 },
            new TestPrecieux { Valeur = 12 },
            new TestPrecieux { Valeur = 44 },
            new TestPrecieux { Valeur = 1 }
        };

        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);

        // Assert
        Assert.AreEqual(44, plusPrecieux.Valeur);
    }

    [Test]
    public void TrouverPlusPrecieux_ValeursNegatives()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = -3 },
            new TestPrecieux { Valeur = -1 },
            new TestPrecieux { Valeur = 4 },
            new TestPrecieux { Valeur = -30 },
            new TestPrecieux { Valeur = 9 },
            new TestPrecieux { Valeur = 15 },
            new TestPrecieux { Valeur = -7 },
            new TestPrecieux { Valeur = 9 }
        };

        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);

        // Assert
        Assert.AreEqual(15, plusPrecieux.Valeur);
    }

    [Test]
    public void TrouverPlusPrecieux_UnElement()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = 10 }
        };

        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);

        // Assert
        Assert.AreEqual(10, plusPrecieux.Valeur);
    }

    [Test]
    public void TrouverPlusPrecieux_Vide()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() { };

        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);

        // Assert
        Assert.AreEqual(null, plusPrecieux);
    }
}
