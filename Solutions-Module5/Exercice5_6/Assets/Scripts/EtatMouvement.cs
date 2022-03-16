using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

abstract class EtatMouvement
{
    public GameObject Sujet
    {
        set;
        get;
    }
    public GameObject Joueur
    {
        set;
        get;
    }

    public NavMeshAgent AgentMouvement
    {
        set;
        get;
    }

    public Animator Animations
    {
        set;
        get;
    }

    public EtatMouvement(GameObject sujet, GameObject joueur)
    {
        Sujet = sujet;
        Joueur = joueur;
        AgentMouvement = sujet.GetComponent<NavMeshAgent>();
        Animations = sujet.GetComponent<Animator>();
    }

    public abstract void Enter();
    public abstract void Handle();
    public abstract void Leave();
}
