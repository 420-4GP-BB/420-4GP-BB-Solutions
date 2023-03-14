using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementSquelette : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsPatrouille;
    private NavMeshAgent _agent;
    private int _indexPatrouille;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _indexPatrouille = 0;
        _agent.destination = _pointsPatrouille[_indexPatrouille].position;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= 0.1f)
            {
                _agent.destination = _pointsPatrouille[_indexPatrouille].position;
                _indexPatrouille = (_indexPatrouille + 1) % _pointsPatrouille.Length;
                _animator.SetBool("Walk",true);
            }
        }

    }
}
