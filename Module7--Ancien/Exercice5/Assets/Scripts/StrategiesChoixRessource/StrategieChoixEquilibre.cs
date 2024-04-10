using UnityEngine;

public class StrategieChoixEquilibre : StrategieChoixRessource
{
    public override int ChoisirRessource(Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
        int indexMax = 0;
        float distanceMax = Vector3.Distance(ressources[0].transform.position, villageois.transform.position);
        float valeurMax = ressources[0].Valeur / (distanceMax * distanceMax);

        for (int i = 1; i < nbRessourcesDisponibles; i++)
        {
            var distance = Vector3.Distance(ressources[i].transform.position, villageois.transform.position);
            float valeurSelonDistance = ressources[i].Valeur / (distance * distance);

            if (valeurSelonDistance > valeurMax)
            {
                valeurMax = valeurSelonDistance;
                indexMax = i;
            }
        }

        return indexMax;
    }
}