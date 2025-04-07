public class Utilitaires
{
    // Classe de m�thodes static, on ne devrait pas l'instancier
    private Utilitaires()
    {
    }

    /**
     * Donne du plus grand �l�ment dans le tableau, en commen�ant �
     * `indexDepart` (on ignore les �l�ments avant)
     */
    public static int PlusGrandElementTableau(int[] tableau, int indexDepart)
    {
        // CORRECTION APPORT�E 2: S'il n'y a pas d'�l�ments dans ce qu'on cherche, on retourne -1
        if (tableau.Length == 0 || indexDepart >= tableau.Length)
            return -1;

        // CORRECTION APPORT�E 4: prendre en compte indexDepart ici
        int indexMax = indexDepart;
        int valeurMax = tableau[indexDepart];

        // CORRECTION APPORT�E 3: l'index de d�part �tait mal g�r� ici (enlever le `- indexDepart`)
        for (int i = indexDepart; i < tableau.Length; i++)
        {
            // CORRECTION APPORT�E 1: >= devient >
            if (tableau[i] > valeurMax)
            {
                valeurMax = tableau[i];
                indexMax = i;
            }
        }

        return indexMax;
    }
}