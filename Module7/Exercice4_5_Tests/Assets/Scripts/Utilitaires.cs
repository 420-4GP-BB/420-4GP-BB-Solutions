using System.Collections.Generic;

public static class Utilitaires
{
    public static IPrecieux TrouverPlusPrecieux(IEnumerable<IPrecieux> listePrecieux)
    {
        IPrecieux plusPrecieux = null;
        foreach (IPrecieux precieux in listePrecieux)
        {
            if (plusPrecieux == null || precieux.Valeur > plusPrecieux.Valeur)
            {
                plusPrecieux = precieux;
            }
        }
        return plusPrecieux;
    }
}
