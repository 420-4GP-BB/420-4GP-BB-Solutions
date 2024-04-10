using UnityEngine;

public class StrategieChoixHasard : StrategieChoixRessource
{
    public override int ChoisirRessource(Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
        return Random.Range(0, nbRessourcesDisponibles);
    }
}