public abstract class StrategieChoixRessource
{
    /// <summary>
    /// Méthode qui décide du numéro de ressource à aller chercher en prochain.
    /// La méthode requiert qu'au moins une ressource soit disponible.
    /// </summary>
    /// <param name="villageois">Villageois qui cherche sa prochaine ressource</param>
    /// <param name="ressources">Tableau de ressources disponibles (avec des
    /// cases null à la fin pour les ressources déjà collectées)</param>
    /// <param name="nbRessourcesDisponibles">Nombre de ressources encore disponibles dans le tableau de ressources</param>
    /// <returns>Le numéro de la ressource choisie</returns>
    public abstract int ChoisirRessource(Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles);
}