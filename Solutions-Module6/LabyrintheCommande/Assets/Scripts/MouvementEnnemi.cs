using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementEnnemi : MonoBehaviour
{
    public delegate void PartiePerdue();
    public event PartiePerdue PartiePerdueHandler;
    
    [SerializeField] private GameObject joueur;
    [SerializeField] private float vitesseEnnemi;
    [field: SerializeField]
    public GameObject[] Waypoints
    {
        set;
        get;
    }

    public EtatMouvementEnnemi Etat
    {
        set;
        get;
    }

    public EtatAttaqueEnnemi Attaque
    {
        set;
        get;
    }

    public EtatPatrouilleEnnemi Patrouille
    {
        set;
        get;
    }

    public EtatMort Mort
    {
        set;
        get;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Solution qui utilise toujours le même état. Il serait possible, selon le contexte,
        // de créer un nouvel état à chaque transition.
        Patrouille = new EtatPatrouilleEnnemi(this, joueur);
        Attaque = new EtatAttaqueEnnemi(this, joueur);
        Mort = new EtatMort(this, joueur);
        Etat = Patrouille;
    }

    // Update is called once per frame
    void Update()
    {
        Etat.Deplacer();
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject == joueur)
        {
            PartiePerdueHandler();
        }
    }

    public bool EstBlesse()
    {
        PointDeVie pdv = gameObject.GetComponent<PointDeVie>();
        return pdv.EstBlesse();
    } 
    
}
