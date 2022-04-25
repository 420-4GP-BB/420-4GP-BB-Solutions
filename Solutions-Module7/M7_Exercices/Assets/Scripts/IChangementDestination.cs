using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Interface qui définit le comportement de gestion des destinations
/// </summary>
public interface IChangementDestination
{
    /// <summary>
    /// Permet de changer de destination
    /// </summary>
    /// <param name="nouvelle">La nouvelle destination</param>
    void ChangerPositionCible(Vector3 position);

    /// <summary>
    /// Retourne vrai si la position actuelle correspond à la position cible
    /// </summary>
    /// <param name="positionActuelle">La position actuelle de l'objet</param>
    /// <returns>Vrai si on est rendu au point voulu</returns>
    bool DestinationAtteinte();

    /// <summary>
    /// Permet d'arreter.
    /// </summary>
    void Arreter();

    /// <summary>
    /// Premet de reprendre
    /// </summary>
    void Reprendre();
}

