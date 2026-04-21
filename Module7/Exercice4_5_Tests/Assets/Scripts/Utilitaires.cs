using System.Collections.Generic;

public static class Utilitaires
{
    public static IPrecieux TrouverPlusPrecieux(IEnumerable<IPrecieux> precieuxListe)
    {
        if (precieuxListe == null) return null;

        IPrecieux plusPrecieux = null;
        foreach (IPrecieux item in precieuxListe)
        {
            if (plusPrecieux == null || item.Valeur > plusPrecieux.Valeur)
            {
                plusPrecieux = item;
            }
        }
        return plusPrecieux;
    }
}
