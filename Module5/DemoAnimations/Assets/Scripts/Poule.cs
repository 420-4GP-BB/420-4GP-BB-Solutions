using System.Collections;
using EtatsPoule;
using UnityEngine;

public class Poule : MonoBehaviour
{
    private Animator _Animator;
    public Animator Animator => _Animator;

    private EtatPoule _Etat;

    [SerializeField] public float Vitesse = 1;
    [SerializeField] public GameObject Cible;
    [SerializeField] public Vector3 PositionCentre = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Etat = new EtatCalme(this);
        _Etat.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        _Etat.Handle();
    }

    public void Heurter()
    {
        _Etat.Heurter();
    }

    public void ChangerEtat(EtatPoule etat)
    {
        _Etat.Exit();
        _Etat = etat;
        _Etat.Enter();
    }

    public void Attaquer()
    {
        // Attaque la cible
        StartCoroutine(Brasser());
    }

    private IEnumerator Brasser()
    {
        float temps = 0;

        var positionBase = Cible.transform.position;

        while (temps < 0.75f)
        {
            temps += Time.deltaTime;
            // Brasse au hasard en X
            Cible.transform.position = positionBase +
                                       new Vector3(
                                           Random.value * 0.5f,
                                           Random.value * 0.5f,
                                           Random.value * 0.5f);
            yield return null;
        }

        Cible.transform.position = positionBase;
    }
}