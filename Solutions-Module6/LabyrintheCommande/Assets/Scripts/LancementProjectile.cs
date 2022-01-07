using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LancementProjectile : MonoBehaviour
{
    public delegate void ChangementNombreProjectiles();
    public event ChangementNombreProjectiles ChangementNombreProjectilesHandler;

    [SerializeField] private GameObject projectile;
    [SerializeField] private AudioSource sonProjectile;

    public int QuantiteProjectile
    {
        set;
        get;
    }
    private void Awake()
    {
        QuantiteProjectile = GameManager.Instance().NombreBalles;
    }

    public void LancerProjectile()
    {
        if (QuantiteProjectile > 0)
        {
            GameObject nouveauProjectile = GameObject.Instantiate(projectile);
            nouveauProjectile.transform.position = transform.position + transform.forward * 2 + Vector3.up;
            nouveauProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000 + Vector3.up * 100);
            QuantiteProjectile--;
            ChangementNombreProjectilesHandler();
            sonProjectile.Play();
            StartCoroutine(DetruireProjectile(nouveauProjectile));
        }
    }

    private IEnumerator DetruireProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(projectile);
    }
}
