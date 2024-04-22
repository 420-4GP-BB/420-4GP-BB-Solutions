using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementSquelette : MonoBehaviour, IMortel
{
    [SerializeField] private Transform[] _pointsPatrouille;

    private NavMeshAgent _agent;
    private Animator _animator;

    private EtatSquelette _etat;

    [SerializeField]
    private EtatPatrouille _etatPatrouille;

    // PATCH: Pour aller chercher le point de patrouille.
    public int _indicePatrouille;

   

    // PATCH: Les points de patrouille sont écrasés par la restauration de la sauvegarde
    // on doit y accéder afin de reconstruire l'objet EtatPatrouille
    internal Transform[] PointsPatrouille
    {
        get => _pointsPatrouille;
        set => _pointsPatrouille = value;
    }

    public EtatPatrouille Patrouille
    {
        get => _etatPatrouille;
        set => _etatPatrouille = value;
    }

    public EtatPoursuite Poursuite
    {
        private set;
        get;
    }

    public EtatAttente Attente
    {
        private set;
        get;
    }

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        GameObject joueur = GameObject.Find("Joueur");
        _etatPatrouille = new EtatPatrouille(this, joueur, _pointsPatrouille, 0);
        Poursuite = new EtatPoursuite(this, joueur);
        Attente = new EtatAttente(this, joueur);
    }

    void Start()
    {
        _etat = _etatPatrouille;
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

    public void Mourir()
    {
        ChangerEtat(new EtatMort(this, null));
    }
}
