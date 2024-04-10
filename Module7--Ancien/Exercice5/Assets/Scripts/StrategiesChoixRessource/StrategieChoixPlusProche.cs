using UnityEngine;

public class StrategieChoixPlusProche : StrategieChoixRessource
{
    public override int ChoisirRessource(Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
        int indexMin = 0;
        float distanceMin = Vector3.Distance(villageois.transform.position, ressources[0].transform.position);

        for (int i = 1; i < nbRessourcesDisponibles; i++)
        {
            var distance = Vector3.Distance(ressources[i].transform.position, villageois.transform.position);
            if (distance < distanceMin)
            {
                distanceMin = distance;
                indexMin = i;
            }
        }

        return indexMin;
    }
}