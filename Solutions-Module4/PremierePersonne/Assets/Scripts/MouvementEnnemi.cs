using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementEnnemi : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float vitesseEnnemi;

    
    private Vector3 _objectif;
    private int _indiceObjectifs;
    private NavMeshAgent _meshAgent;
    // Start is called before the first frame update
    void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        _objectif = waypoints[0].transform.position;
        _indiceObjectifs = 0;
        _meshAgent.destination = _objectif;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Vector3.Distance(position, _objectif) <= 0.1f)
        {
            _indiceObjectifs = (_indiceObjectifs + 1) % waypoints.Length;
            _objectif = waypoints[_indiceObjectifs].transform.position;
            _meshAgent.destination = _objectif;
        }
    }
}
