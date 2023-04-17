using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancementProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    private AudioSource _sonLancement;

    // Start is called before the first frame update
    void Start()
    {
        _sonLancement = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject nouveau = Instantiate(_projectile);
            nouveau.transform.position = transform.position + transform.forward * 1.5f;
            nouveau.GetComponent<Rigidbody>().AddForce(transform.forward * 1000 + Vector3.up * 100);
            _sonLancement.Play();
            StartCoroutine(AttendreEtDetruire(nouveau));
        }
    }

    private IEnumerator AttendreEtDetruire(GameObject projectile)
    {
        yield return new WaitForSeconds(3);
        Destroy(projectile);
    }
}
