using System.Collections.Generic;
using UnityEngine;

public class StrategieChoixEquilibre : StrategieChoixRessource
{
    public override int ChoisirRessource(Villageois villageois, List<Ressource> ressources)
    {
        // On choisit la premiere ressource comme max
        int indexMax = 0;
        float distanceMax = Vector3.Distance(villageois.transform.position, ressources[0].transform.position);
        float valeurMax = ressources[0].valeur / (distanceMax * distanceMax);

        // On compare avec les autres ressources
        for (int i = 1; i < ressources.Count; i++)
        {
            float distance = Vector3.Distance(villageois.transform.position, ressources[i].transform.position);
            float valeur = ressources[i].valeur / (distance * distance);

            if (valeur > valeurMax)
            {
                valeurMax = valeur;
                indexMax = i;
            }
        }

        return indexMax;
    }
}