using System.Collections.Generic;
using UnityEngine;

public class StrategieChoixHasard : StrategieChoixRessource
{
    public override int ChoisirRessource(Villageois villageois, List<Ressource> ressources)
    {
        return Random.Range(0, ressources.Count);
    }
}