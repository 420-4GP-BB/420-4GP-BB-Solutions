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

    private GameManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameManager.Instance();
        inputBalles.text = GameManager.Instance().NombreBalles.ToString();
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
        if (_manager.EnPause)
        {
            MontrerMenu();
        }
        else
        {
            CacherMenu();
        }
    }

    private void MontrerMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        menu.enabled = true;
    }

    private void CacherMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menu.enabled = false;
    }

    public void NouvellePartie()
    {
        float vitesseEnnemi = TrouverVitesseEnnemi();
        GameManager.Instance().VitesseEnnemi = vitesseEnnemi;
        GameManager.Instance().NombreBalles = int.Parse(inputBalles.text);
        SceneManager.LoadScene("Exercice 7");
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

    public void Retourner()
    {
        InverserPause();
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
