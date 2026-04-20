using System.Collections.Generic;
using UnityEngine;

public class StrategieChoixPlusProche : StrategieChoixRessource
{
    public override int ChoisirRessource(Villageois villageois, List<Ressource> ressources)
    {
        // On choisit la premiere ressource comme min
        int indexMin = 0;
        float distanceMin = Vector3.Distance(villageois.transform.position, ressources[0].transform.position);

        // On compare avec les autres ressources
        for (int i = 1; i < ressources.Count; i++)
        {
            float distance = Vector3.Distance(villageois.transform.position, ressources[i].transform.position);

            if (distance < distanceMin)
            {
                distanceMin = distance;
                indexMin = i;
            }
        }

        return indexMin;
    }
}