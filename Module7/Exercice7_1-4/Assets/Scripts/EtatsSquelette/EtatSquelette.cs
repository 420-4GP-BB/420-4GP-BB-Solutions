using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EtatSquelette
{
    public MouvementSquelette Squelette
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

    public Animator Animateur
    {
        set;
        get;
    }

    public EtatSquelette(MouvementSquelette squelette, GameObject joueur)
    {
        Squelette = squelette;
        Joueur = joueur;
        AgentMouvement = squelette.GetComponent<NavMeshAgent>();
        Animateur = squelette.GetComponent<Animator>();
    }

    protected bool JoueurVisible()
    {
        bool visible = false;
        RaycastHit hit;


        // PATCH: On place les y au même niveau pour éviter les problème. 
        Vector3 positionJoueur = new Vector3(Joueur.transform.position.x, 0.5f, Joueur.transform.position.z);
        Vector3 positionSquelette = new Vector3(Squelette.transform.position.x, 0.5f, Squelette.transform.position.z);
        Vector3 directionJoueur = positionJoueur - positionSquelette;

        // Regarde s'il y a un obstacle entre le squelette et le joueur
        if (Physics.Raycast(positionSquelette, directionJoueur, out hit))
        {
            if (hit.transform == Joueur.transform)
            {
                // Il n'y a pas d'obstacle, on vérifie l'angle
                float angle = Vector3.Angle(Squelette.transform.forward, directionJoueur);
                visible = angle <= 40.0f;
            }
        }

        return visible;
    }

    public abstract void Enter();
    public abstract void Handle(float deltaTime);
    public abstract void Leave();

}
