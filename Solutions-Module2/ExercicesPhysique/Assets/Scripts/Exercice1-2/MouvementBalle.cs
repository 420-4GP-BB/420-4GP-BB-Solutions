using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBalle : MonoBehaviour
{
    [SerializeField] private float forceBalle;

    private Rigidbody _rbody;
    private float _horizontal;
    private float _vertical;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
    }
    
    void FixedUpdate()
    {
        Vector3 directionForce = new Vector3(_horizontal, 0, _vertical);
        Vector3 forceApplicable = directionForce * forceBalle * Time.fixedDeltaTime;
        _rbody.AddForce(forceApplicable);
    }
}
