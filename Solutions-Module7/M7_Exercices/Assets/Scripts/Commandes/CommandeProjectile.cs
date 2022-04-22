using UnityEngine;

/// <summary>
/// Classe qui envoie un projectile
/// </summary>
public class CommandeProjectile : ICommande
{
    /// <summary>
    /// L'instance où on lance le projectile
    /// </summary>
    private LancementProjectile projectile;

    /// <summary>
    /// L'objet à partir duquel on lance le projectile
    /// </summary>
    private GameObject objetDepart;

    /// <summary>
    /// Commande qui permet de lancer un projectile
    /// </summary>
    /// <param name="sujet"></param>
    public CommandeProjectile(LancementProjectile sujet)
    {
        projectile = sujet;
        objetDepart = sujet.gameObject;
    }

    public void ExecuterCommande()
    {
        Vector3 pointDepart = objetDepart.transform.position + objetDepart.transform.forward * 2;
        Vector3 force = objetDepart.transform.forward * 1000 + Vector3.up * 100;
        projectile.LancerProjectile(pointDepart, force);
    }
}
