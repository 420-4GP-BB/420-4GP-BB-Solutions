/// <summary>
/// Interface qui permet de créer des commandes
/// </summary>
public interface ICommande
{    
    /// <summary>
    /// Méthode qu'il faut implémenter pour exécuter la commande
    /// </summary>
    public void ExecuterCommande();
}