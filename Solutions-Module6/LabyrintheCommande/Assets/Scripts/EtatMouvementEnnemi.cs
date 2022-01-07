using UnityEngine;
using UnityEngine.AI;

public abstract class EtatMouvementEnnemi
{
    protected MouvementEnnemi Mouvement
    {
       private set;
        get;
    }
    
    protected NavMeshAgent Agent
    {
        private set;
        get;
    }

    protected GameObject Joueur
    {
        private set;
        get;
    }

    public EtatMouvementEnnemi(MouvementEnnemi ennemi, GameObject joueur)
    {
        Mouvement = ennemi;
        Agent = ennemi.GetComponent<NavMeshAgent>();
        Joueur = joueur;
    }


    protected bool JoueurVisible()
    {
        bool visible = false;
        RaycastHit hit;
        if (Physics.Raycast(Mouvement.transform.position, Joueur.transform.position - Mouvement.transform.position,
            out hit))
        {
            visible = hit.transform == Joueur.transform;
        }
        return visible;
    }
    public abstract  void Deplacer();
}
