using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinPartie : MonoBehaviour
{
    [SerializeField] private Canvas ecranVictoire;
    [SerializeField] private Canvas ecranDefaite;
    [SerializeField] private MouvementCharacter joueur;


    // Start is called before the first frame update
    void Start()
    {
        ecranDefaite.enabled = false;
        ecranVictoire.enabled = false;
        joueur.ObjectifAtteintHandler += AfficherVictoire;
        joueur.PartiePerdueHandler += AfficherDefaite;
    }

    public void AfficherVictoire()
    {
        ecranVictoire.enabled = true;
        StartCoroutine(AttendreEtQuitter());
    }

    public void AfficherDefaite()
    {
        ecranDefaite.enabled = true;
        StartCoroutine(AttendreEtQuitter());
    }

    private IEnumerator AttendreEtQuitter()
    {
        yield return new WaitForSeconds(2.0f);
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif    
    }
}
