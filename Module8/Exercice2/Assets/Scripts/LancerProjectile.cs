using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _modeleProjectile;
    [SerializeField] private float force;

    private bool _lancerProjectile = false;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _lancerProjectile = true;
        }
    }

    private void FixedUpdate()
    {
        if (_lancerProjectile)
        {
            GameObject projectile = Instantiate(_modeleProjectile);
            projectile.transform.position = transform.position + transform.forward;
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * force + Vector3.up * 50);
            _lancerProjectile = false;
        }
    }
}
 
