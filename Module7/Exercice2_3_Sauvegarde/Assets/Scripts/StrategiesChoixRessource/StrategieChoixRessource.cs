using System.Collections.Generic;

public abstract class StrategieChoixRessource
{
    public abstract TypeStrategie Type { get; }
    public abstract int ChoisirRessource(Villageois villageois, List<Ressource> ressources);
}