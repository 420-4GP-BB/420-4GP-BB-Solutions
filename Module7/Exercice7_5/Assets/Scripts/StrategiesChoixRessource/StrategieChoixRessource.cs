public abstract class StrategieChoixRessource
{
    /// <summary>
    /// M�thode qui d�cide du num�ro de ressource � aller chercher en prochain.
    /// La m�thode requiert qu'au moins une ressource soit disponible.
    /// </summary>
    /// <param name="villageois">Villageois qui cherche sa prochaine ressource</param>
    /// <param name="ressources">Tableau de ressources disponibles (avec des
    /// cases null � la fin pour les ressources d�j� collect�es)</param>
    /// <param name="nbRessourcesDisponibles">Nombre de ressources encore disponibles dans le tableau de ressources</param>
    /// <returns>Le num�ro de la ressource choisie</returns>
    public abstract int ChoisirRessource(Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles);
}