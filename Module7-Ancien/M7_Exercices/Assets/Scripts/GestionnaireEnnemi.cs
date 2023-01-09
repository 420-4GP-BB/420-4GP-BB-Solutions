using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GestionnaireEnnemi : MonoBehaviour
{
    [SerializeField] private GameObject[] tabEnnemis;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in tabEnnemis)
        {
            PointDeVie pointDeVie = obj.GetComponent<PointDeVie>();
            pointDeVie.AtteintZeroHandler += EnnemiDetruit;
        }
    }

    private void EnnemiDetruit(GameObject ennemi)
    {
        Animator animateur = ennemi.GetComponent<Animator>();
        NavMeshAgent agent = ennemi.GetComponent<NavMeshAgent>();
        animateur.SetBool("Dead", true);
        agent.isStopped = true;
        StartCoroutine(AttendreEtDetruire(ennemi));
    }

    /// <summary>
    /// Attends 3 secondes et détruit l'objet
    /// </summary>
    /// <returns>yield... c'est une coroutine</returns>
    private IEnumerator AttendreEtDetruire(GameObject ennemi)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(ennemi);
    }
}
