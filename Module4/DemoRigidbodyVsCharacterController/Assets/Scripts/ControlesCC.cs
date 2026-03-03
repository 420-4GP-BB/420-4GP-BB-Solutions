using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesCC : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        transform.Rotate(0, horizontal, 0);
        _characterController.SimpleMove(transform.forward * (vertical * speed));
    }
}
