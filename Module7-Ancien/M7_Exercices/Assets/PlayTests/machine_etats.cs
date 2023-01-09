using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class machine_etats
{
    [UnityTest]
    public IEnumerator etat_initial_est_patrouille()
    {
        // ARRANGE
        GameObject ennemi = new GameObject();
        MouvementEnnemi mouvement = ennemi.AddComponent<MouvementEnnemi>();
        ennemi.AddComponent<Animator>();
        IChangementDestination mockDestination = Substitute.For<IChangementDestination>();
        mouvement.Construct(CreerPoints(), mockDestination);

        GameObject joueur = new GameObject("Joueur");

        // ACT
        yield return null;   // Fait en sorte que Start s'exécute sur les composants

        // ASSERT
        Assert.IsInstanceOf(typeof(EtatPatrouille), mouvement.EtatCourant);
    }

    [UnityTest]
    public IEnumerator etat_passe_a_poursuite_si_joueur_est_visible()
    {
        // ARRANGE
        GameObject ennemi = new GameObject();
        ennemi.transform.position = Vector3.zero;

        MouvementEnnemi mouvement = ennemi.AddComponent<MouvementEnnemi>();
        GameObject joueur = new GameObject("Joueur");
        joueur.transform.position = Vector3.forward;
        joueur.AddComponent<BoxCollider>();

        IChangementDestination mockDestination = Substitute.For<IChangementDestination>();
        mouvement.Construct(CreerPoints(), mockDestination);

        Animator animateur = ennemi.AddComponent<Animator>();



        // ACT
        yield return null;   // Fait en sorte que Start s'exécute sur les composants
        yield return null;   // Le joueur devrait être visible puisqu'il n'y a rien entre l'ennemi et le joueur
        // ASSERT
        Assert.IsInstanceOf(typeof(EtatPoursuite), mouvement.EtatCourant);
    }

    [UnityTest]
    public IEnumerator etat_reste_a_patrouille_si_joueur_est_pas_visible()
    {
        // ARRANGE
        GameObject ennemi = new GameObject();
        ennemi.transform.position = Vector3.zero;
        ennemi.transform.localScale = Vector3.one;
        MouvementEnnemi mouvement = ennemi.AddComponent<MouvementEnnemi>();

        GameObject obstacle = new GameObject();
        obstacle.transform.position = Vector3.forward * 2;
        obstacle.transform.localScale = Vector3.one;
        obstacle.AddComponent<BoxCollider>();

        GameObject joueur = new GameObject("Joueur");
        joueur.transform.position = Vector3.forward * 4;
        joueur.AddComponent<BoxCollider>();

        IChangementDestination mockDestination = Substitute.For<IChangementDestination>();
        mouvement.Construct(CreerPoints(), mockDestination);

        Animator animateur = ennemi.AddComponent<Animator>();

        // ACT
        yield return null;   // Fait en sorte que Start s'exécute sur les composants
        yield return null;   // Le joueur ne devrait pas être visible puisqu'il y a un obstacle entre l'ennemi et le joueur
        // ASSERT
        Assert.IsInstanceOf(typeof(EtatPatrouille), mouvement.EtatCourant);
    }


    private Transform[] CreerPoints()
    {
        Transform[] tabPoints = new Transform[4];
        for (int i = 0; i < tabPoints.Length; i++)
        {
            tabPoints[i] = new GameObject().transform;
        }

        tabPoints[0].position = Vector3.zero;
        tabPoints[1].position = Vector3.up;
        tabPoints[2].position = Vector3.down;
        tabPoints[3].position = Vector3.one;

        return tabPoints;
    }
}
