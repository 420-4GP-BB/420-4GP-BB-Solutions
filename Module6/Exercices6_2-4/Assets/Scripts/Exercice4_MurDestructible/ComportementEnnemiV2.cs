using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Cette classe n'est pas utilisée dans le projet, il s'agit simplement d'une ébauche de solutionnaire
public class ComportementEnnemiV2 : MonoBehaviour, IBrisable
{
    public List<GameObject> pointPatrouilles;
    public GameObject joueur;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animateur;

    // [...]
    // Cette classe contiendrait tout ce que la classe ComportementEnnemi contient déjà
    
    // On ajoute :
    public void Detruire()
    {
        // Le concept ici est de lancer la transition vers l'état mort depuis cette méthode,
        // qui est partagée par tous les objets de type IBrisable
        
        // ChangerEtat(new EtatMort(this));
    }
}
