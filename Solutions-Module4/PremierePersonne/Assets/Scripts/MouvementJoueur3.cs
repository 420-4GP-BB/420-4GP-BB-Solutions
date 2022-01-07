using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur3 : MonoBehaviour
{
    [SerializeField] private float vitesse;
    private Rigidbody _rigidbody;
    private Vector3 _deplacement;

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * vitesse * Time.fixedDeltaTime;
        float vertical = Input.GetAxis("Vertical") * vitesse * Time.fixedDeltaTime;
        _deplacement = transform.TransformDirection(new Vector3(horizontal, 0, vertical));
        _rigidbody.MovePosition(_rigidbody.position + _deplacement);
    }
}
