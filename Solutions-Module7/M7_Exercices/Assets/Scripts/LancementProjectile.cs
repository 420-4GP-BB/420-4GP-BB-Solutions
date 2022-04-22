using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script qui lance un projectile à partir d'un point. Il faut spécifier le prefab du projectile.
///
/// Auteur: Eric Wenaas
/// </summary>
public class LancementProjectile : MonoBehaviour
{
    /// <summary>
    /// Le prefab du projectile
    /// </summary>
    [SerializeField] private GameObject modeleProjectile;

    /// <summary>
    /// Le son du projectile
    /// </summary>
    [SerializeField] private AudioSource sonProjectile;

    /// <summary>
    /// Instantie le projectile et lui applique la force spécifiée en paramêtre
    /// </summary>
    /// <param name="positionDepart">La position de départ du projectile</param>
    /// <param name="force">La force à appliquer au projectile</param>
    public void LancerProjectile(Vector3 positionDepart, Vector3 force)
    {
        GameObject nouveau = GameObject.Instantiate(modeleProjectile);
        nouveau.transform.position = positionDepart;
        nouveau.GetComponent<Rigidbody>().AddForce(force);
        sonProjectile.Play();
        StartCoroutine(DetruireProjectile(nouveau));
    }

    /// <summary>
    /// Destruction du projectile après 3 secondes s'il n'est pas déjà détruit
    /// </summary>
    /// <param name="projectile">Le projectile</param>
    /// <returns>yield car c'est une coroutine</returns>
    private IEnumerator DetruireProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(3.0f);
        if (projectile != null)
        {
            Destroy(projectile);
        }
    }
}
