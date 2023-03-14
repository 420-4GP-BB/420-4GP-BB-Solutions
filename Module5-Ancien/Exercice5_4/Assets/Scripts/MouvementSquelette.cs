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

    private EtatSquelette _etat;
    // Start is called before the first frame update

    public EtatMouvementSquelette EtatMouvement
    {
        private set;
        get;
    }

    public EtatPoursuiteSquelette EtatPoursuite
    {
        private set;
        get;
    }

    public EtatAttenteSquelette EtatAttente
    {
        private set;
        get;
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _indexPatrouille = 0;
        _agent.destination = _pointsPatrouille[_indexPatrouille].position;
        _animator = GetComponent<Animator>();
        EtatMouvement = new EtatMouvementSquelette(gameObject, GameObject.Find("Joueur"), _pointsPatrouille);
        EtatPoursuite = new EtatPoursuiteSquelette(gameObject, GameObject.Find("Joueur"));
        EtatAttente = new EtatAttenteSquelette(gameObject, GameObject.Find("Joueur"));

        _etat = EtatMouvement;
        _etat.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        _etat.Handle(Time.deltaTime);
    }

    public void ChangerEtat(EtatSquelette nouvelEtat)
    {
        _etat.Leave();
        _etat = nouvelEtat;
        _etat.Enter();
    }

}
