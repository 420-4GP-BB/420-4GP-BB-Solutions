using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ChangementNombreProjectiles();

public class LancerProjectile : MonoBehaviour
{
    public event ChangementNombreProjectiles ChangementNombreProjectilesHandler;

    [SerializeField] private GameObject projectile;

    public int QuantiteProjectile
    {
        set;
        get;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        QuantiteProjectile = GameManager.Instance().NombreBalles;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance().EnPause)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") && QuantiteProjectile > 0)
        {
            GameObject nouveauProjectile = GameObject.Instantiate(projectile);
            nouveauProjectile.transform.position = transform.position + transform.forward * 2 + Vector3.up;
            nouveauProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000 + Vector3.up * 100);
            QuantiteProjectile--;
            ChangementNombreProjectilesHandler();
            StartCoroutine(DetruireProjectile(nouveauProjectile));
        }
    }

    private IEnumerator DetruireProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(projectile);
    }



}
