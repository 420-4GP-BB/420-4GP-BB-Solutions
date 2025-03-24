using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ComportementPoule : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Collider _plancher;

    private bool _toucheLeSol = true;
    private Animator _animator;
    [SerializeField] private float _forceSaut;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_toucheLeSol)
        {
            _animator.SetFloat("State", 0);
            _animator.SetFloat("Vert", 0);
        }
        else
        {
            _animator.SetFloat("State", 1);
            _animator.SetFloat("Vert", 1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == _plancher)
            _toucheLeSol = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider == _plancher)
            _toucheLeSol = false;
    }

    public void Sauter()
    {
        if (_toucheLeSol)
            _rb.AddForce(Vector3.up * _forceSaut, ForceMode.Impulse);
    }
}