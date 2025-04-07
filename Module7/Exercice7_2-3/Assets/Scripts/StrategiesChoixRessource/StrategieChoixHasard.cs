using UnityEngine;

public class StrategieChoixHasard : StrategieChoixRessource
{
    public override int ID => 0;

    public override int ChoisirRessource(Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
        return Random.Range(0, nbRessourcesDisponibles);
    }
}