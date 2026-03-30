using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Cette classe n est pas utilisee, il est une ebauche de solutionnaire
public class ComportementEnnemiV2 : MonoBehaviour, IBrisable
{
    public List<GameObject> pointPatrouilles;
    public GameObject joueur;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animateur;

    // [...]
    // Cette classe contiendrait tout ce que la classe ComportementEnnemi contient
    
    // On ajoute :
    public void Detruire()
    {
        // Le concept ici est de lancer la transition vers l etat mort depuis cette methode,
        // qui est partagee par tous les objets de type IBrisable
        
        // ChangerEtat(EtatMort);
    }
}
