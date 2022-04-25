using UnityEngine;

public class MouvementEnnemi : MonoBehaviour
{

    /// <summary>
    /// Les points de la patrouille
    /// </summary>
    [SerializeField] private Transform[] pointsPatrouille;

    private EtatMouvement mouvement;
    private EtatPatrouille patrouille;

    public EtatMouvement EtatCourant
    {
        get { return mouvement; }
    }


    internal EtatPatrouille Patrouille
    {
        get { return patrouille; }
    }

    public void Construct(Transform[] points)
    {
        pointsPatrouille = points;
    }


    // Start is called before the first frame update
    void Start()
    {
        patrouille = new EtatPatrouille(gameObject, pointsPatrouille, GameObject.Find("Joueur"), GetComponent<ChangementDestinationNavMesh>());
        mouvement = patrouille;
        patrouille.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        mouvement.Handle();    
    }

    internal void ChangerEtat(EtatMouvement nouvelEtat)
    {
        mouvement.Leave();
        mouvement = nouvelEtat;
        mouvement.Enter();
    }
}

