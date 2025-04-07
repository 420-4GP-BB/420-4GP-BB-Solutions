public class Utilitaires
{
    // Classe de méthodes static, on ne devrait pas l'instancier
    private Utilitaires()
    {
    }

    /**
     * Donne du plus grand élément dans le tableau, en commençant à
     * `indexDepart` (on ignore les éléments avant)
     */
    public static int PlusGrandElementTableau(int[] tableau, int indexDepart)
    {
        // CORRECTION APPORTÉE 2: S'il n'y a pas d'éléments dans ce qu'on cherche, on retourne -1
        if (tableau.Length == 0 || indexDepart >= tableau.Length)
            return -1;

        // CORRECTION APPORTÉE 4: prendre en compte indexDepart ici
        int indexMax = indexDepart;
        int valeurMax = tableau[indexDepart];

        // CORRECTION APPORTÉE 3: l'index de départ était mal géré ici (enlever le `- indexDepart`)
        for (int i = indexDepart; i < tableau.Length; i++)
        {
            // CORRECTION APPORTÉE 1: >= devient >
            if (tableau[i] > valeurMax)
            {
                valeurMax = tableau[i];
                indexMax = i;
            }
        }

        return indexMax;
    }
}