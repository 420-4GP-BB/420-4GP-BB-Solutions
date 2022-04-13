using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Classe qui permet de gérer des points de vie pour les champignons
/// 
/// Auteur: Eric Wenaas
/// </summary>
public class PointDeVie : MonoBehaviour
{
    /// <summary>
    /// Le nombre de point de vie maximum
    /// </summary>
    [SerializeField] private int pointsVieMax;

    /// <summary>
    /// L'animateur des champignons
    /// </summary>
    private Animator animateur;

    private NavMeshAgent agent;

    /// <summary>
    /// Le nombre de points de vie actuel
    /// </summary>
    public int NombrePointsVie
    {
        private set;
        get;
    }

    // Start is called before the first frame update
    void Start()
    {
        NombrePointsVie = pointsVieMax;
        animateur = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }


    /// <summary>
    /// Permet de retirer un montant de points de vie
    /// </summary>
    /// <param name="nombre">Le nombre de points de vie à enlever</param>
    public void RetirerPointDeVie(int nombre)
    {
        NombrePointsVie -= nombre;

        if (NombrePointsVie <= 0)
        {
            TuerChampignon();
        }
    }

    /// <summary>
    /// Méthode qui déclenche l'animation de mort du champignon et le détruit
    /// </summary>
    private void TuerChampignon()
    {
        animateur.SetBool("Dead", true);
        agent.isStopped = true;
        StartCoroutine(AttendreEtDetruire());
    }

    /// <summary>
    /// Attends 3 secondes et détruit l'objet
    /// </summary>
    /// <returns>yield... c'est une coroutine</returns>
    private IEnumerator AttendreEtDetruire()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
