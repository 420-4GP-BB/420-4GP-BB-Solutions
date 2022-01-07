using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject nouveauProjectile = GameObject.Instantiate(projectile);
            nouveauProjectile.transform.position = transform.position + transform.forward * 2 + Vector3.up;
            nouveauProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000 + Vector3.up * 100);
            StartCoroutine(DetruireProjectile(nouveauProjectile));
        }
    }

    private IEnumerator DetruireProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(projectile);
    }

}
