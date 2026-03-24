using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ComportementChat : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private Animator _animator;

    private bool _avance;
    [SerializeField] private float _vitesse = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_destination.position == transform.position)
        {
            // Déjà arrivé
            return;
        }

        if (_avance)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _destination.position, Time.deltaTime * _vitesse);
            _animator.SetFloat("State", 1);
            _animator.SetFloat("Vert", 1);
        }
        else
        {
            _animator.SetFloat("State", 0);
            _animator.SetFloat("Vert", 0);
        }
    }

    public void DebuterAvancer()
    {
        _avance = true;
        transform.LookAt(_destination);
    }
}