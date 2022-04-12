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

    public Animator Animateur
    {
        set;
        get;
    }

    public EtatMouvement(GameObject sujet, GameObject joueur)
    {
        Sujet = sujet;
        Joueur = joueur;
        AgentMouvement = sujet.GetComponent<NavMeshAgent>();
        Animateur = sujet.GetComponent<Animator>();
    }

    protected bool JoueurVisible()
    {
        bool visible = false;
        RaycastHit hit;
        Vector3 directionJoueur = Joueur.transform.position - Sujet.transform.position;

        // Regarde s'il y a un obstacle entre le sujet et le joueur
        if (Physics.Raycast(Sujet.transform.position, directionJoueur, out hit))
        {            
            if (hit.transform == Joueur.transform)
            {
                // Il n'y a pas d'obstacle, on vérifie l'angle
                float angle = Vector3.Angle(Sujet.transform.forward, directionJoueur);
                Debug.Log("Angle: " + angle.ToString());
                visible = angle <= 35.0f;
            }
        }

        return visible;
    }

    public abstract void Enter();
    public abstract void Handle();
    public abstract void Leave();
}
