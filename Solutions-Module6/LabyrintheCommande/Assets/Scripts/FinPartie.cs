using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinPartie : MonoBehaviour
{
    [SerializeField] private Canvas ecranVictoire;
    [SerializeField] private Canvas ecranDefaite;
    [SerializeField] private MouvementCharacter joueur;
    [SerializeField] private AudioSource musiqueVictoire;
    [SerializeField] private AudioSource musiqueDefaite;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] ennemis = GameObject.FindGameObjectsWithTag("Ennemi");
        foreach (var ennemi in ennemis)
        {
            MouvementEnnemi mv = ennemi.GetComponent<MouvementEnnemi>();
            mv.PartiePerdueHandler += AfficherDefaite;
        }
        ecranDefaite.enabled = false;
        ecranVictoire.enabled = false;
        joueur.ObjectifAtteintHandler += AfficherVictoire;
//        joueur.PartiePerdueHandler += AfficherDefaite;
    }

    public void AfficherVictoire()
    {
        ecranVictoire.enabled = true;
        GameManager.Instance().MusiqueFond.Stop();
        musiqueVictoire.Play();
        StartCoroutine(AttendreEtQuitter());
    }

    public void AfficherDefaite()
    {
        ecranDefaite.enabled = true;
        GameManager.Instance().MusiqueFond.Stop();
        GameManager.Instance().MusiqueFond = musiqueDefaite;
        GameManager.Instance().MusiqueFond.Play();
        StartCoroutine(AttendreEtQuitter());
    }

    private IEnumerator AttendreEtQuitter()
    {
        yield return new WaitForSeconds(4.0f);
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif    
    }
}
