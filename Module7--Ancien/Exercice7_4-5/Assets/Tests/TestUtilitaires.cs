using NUnit.Framework;

public class TestUtilitaires
{
    [Test]
    public void PlusGrandElementTableau_Simple()
    {
        // ARRANGE
        int[] tableau = { 5, 3, 8, 12, 9, 1 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 0);

        // ASSERT
        Assert.AreEqual(3, index);
    }

    [Test]
    public void PlusGrandElementTableau_Repete()
    {
        // ARRANGE
        int[] tableau = { 5, 3, 8, 12, 9, 1, 12, 3, 5, 12 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 0);

        // ASSERT
        Assert.AreEqual(3, index);
    }

    [Test]
    public void PlusGrandElementTableau_ValeursNegatives()
    {
        // ARRANGE
        int[] tableau = { -3, -1, 4, -30, 9, 15, -7, 9 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 0);

        // ASSERT
        Assert.AreEqual(5, index);
    }

    [Test]
    public void PlusGrandElementTableau_UnElement()
    {
        // ARRANGE
        int[] tableau = { 5 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 0);

        // ASSERT
        Assert.AreEqual(0, index);
    }

    [Test]
    public void PlusGrandElementTableau_Vide()
    {
        // ARRANGE
        int[] tableau = { };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 0);

        // ASSERT
        Assert.AreEqual(-1, index);
    }


    [Test]
    public void PlusGrandElementTableau_IndexDepartSimple1()
    {
        // ARRANGE
        int[] tableau = { 5, 3, 8, 12, 9, 1 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 2);

        // ASSERT
        Assert.AreEqual(3, index);
    }

    [Test]
    public void PlusGrandElementTableau_IndexDepartSimple2()
    {
        // ARRANGE
        int[] tableau = { 5, 3, 8, 12, 7, 9, 1 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 4);

        // ASSERT
        Assert.AreEqual(5, index);
    }

    [Test]
    public void PlusGrandElementTableau_IndexDepartEstLePlusGrand()
    {
        // ARRANGE
        int[] tableau = { 5, 3, 8, 12, 7, 9, 1 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 3);

        // ASSERT
        Assert.AreEqual(3, index);
    }

    [Test]
    public void PlusGrandElementTableau_IndexDepartEstLaFin()
    {
        // ARRANGE
        int[] tableau = { 5, 3, 8, 12, 7, 9, 1 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 6);

        // ASSERT
        Assert.AreEqual(6, index);
    }


    [Test]
    public void PlusGrandElementTableau_IndexDepartTropHaut()
    {
        // ARRANGE
        int[] tableau = { 5, 3, 8, 12, 7, 9, 1 };

        // ACT
        int index = Utilitaires.PlusGrandElementTableau(tableau, 40);

        // ASSERT
        Assert.AreEqual(-1, index);
    }
}