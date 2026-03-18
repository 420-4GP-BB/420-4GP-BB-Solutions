using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ComportementEnnemi : MonoBehaviour
{
    public List<GameObject> pointPatrouilles;
    public GameObject joueur;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animateur;

    public EtatPatrouille etatPatrouille;
    public EtatPoursuite etatPoursuite;
    public EtatAttente etatAttente;
    public EtatAttaque etatAttaque;

    private EtatEnnemi etatCourant;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animateur = GetComponent<Animator>();

        etatPatrouille = new EtatPatrouille(this);
        etatPoursuite = new EtatPoursuite(this);
        etatAttente = new EtatAttente(this);
        etatAttaque = new EtatAttaque(this);

        etatCourant = etatPatrouille;
        etatCourant.Entrer();
    }

    void Update()
    {
        etatCourant.Executer(Time.deltaTime);
    }

    public void ChangerEtat(EtatEnnemi nouvelEtat)
    {
        if (etatCourant == nouvelEtat) return;

        etatCourant.Sortir();
        etatCourant = nouvelEtat;
        etatCourant.Entrer();
    }

    public bool JoueurVisible()
    {
        Vector3 directionJoueur = (joueur.transform.position - transform.position).normalized;

        // Calcule angle entre forward et direction du joueur
        float angle = Vector3.Angle(transform.forward, directionJoueur);

        if (angle < 60f)
        {
            // Tire un rayon vers le joueur
            if (Physics.Raycast(transform.position, directionJoueur, out RaycastHit hit))
            {
                if (hit.collider.gameObject == joueur)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
