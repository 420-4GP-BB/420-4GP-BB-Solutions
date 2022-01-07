using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AfficherMenu : MonoBehaviour
{
    [SerializeField] private Canvas menu;
    [SerializeField] private InputField inputBalles;
    [SerializeField] private Dropdown listeDifficulte;
    [SerializeField] private AudioSource musiqueMenu;
    [SerializeField] private AudioSource musiqueJeu;
    
    private GameManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameManager.Instance();
        inputBalles.text = GameManager.Instance().NombreBalles.ToString();
        GameManager.Instance().MusiqueFond = musiqueMenu;
        InverserPause();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InverserPause();
        }
    }

    private void InverserPause()
    {
        _manager.InverserPause();
        GameManager.Instance().MusiqueFond.Stop();
        if (_manager.EnPause)
        {
            MontrerMenu();
            GameManager.Instance().MusiqueFond = musiqueMenu;
        }
        else
        {
            CacherMenu();
            GameManager.Instance().MusiqueFond = musiqueJeu;
        }
        GameManager.Instance().MusiqueFond.Play();
    }

    private void MontrerMenu()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        menu.gameObject.SetActive(true);
    }

    private void CacherMenu()
    {
        menu.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void NouvellePartie()
    {
        Time.timeScale = 1;
        float vitesseEnnemi = TrouverVitesseEnnemi();
        GameManager.Instance().VitesseEnnemi = vitesseEnnemi;
        GameManager.Instance().NombreBalles = int.Parse(inputBalles.text);
        SceneManager.LoadScene("Exercice 7");
    }

    public void ReprendrePartie()
    {
        InverserPause();       
    }

    private float TrouverVitesseEnnemi()
    {
        float vitesseEnnemi = 0.0f;
        int valeur = listeDifficulte.value;
        switch(valeur)
        {
            case 0:
                vitesseEnnemi = 2.0f;
                break;
            case 1:
                vitesseEnnemi = 4.0f;
                break;
            case 2:
                vitesseEnnemi = 6.0f;
                break;
        }
        return vitesseEnnemi;
    }
    
    public void Quitter()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
