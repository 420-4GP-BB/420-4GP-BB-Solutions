using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Controleur : MonoBehaviour
{
    [SerializeField] private Button boutonCharger;
    [SerializeField] private TMP_InputField saisieVitesse;
    [SerializeField] private TMP_InputField saisieAcceleration;

    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
        saisieVitesse.text = gameManager.Vitesse.ToString();
        saisieAcceleration.text = gameManager.FacteurAcceleration.ToString();
        Cursor.lockState = CursorLockMode.None;

        // Ajouter la méthode charger partie au bouton
        boutonCharger.onClick.AddListener(RestaurerPartie);
        boutonCharger.interactable = GetComponent<GestionnaireSauvegarde>().FichierExiste;
    }

    public void Quitter()
    {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void RestaurerPartie()
    {
        GetComponent<GestionnaireSauvegarde>().ChargerPartie("Labyrinthe");
    }

    public void ChargerJeu()
    {
        ChangerVitesse();
        ChangerAcceleration();
        SceneManager.LoadScene("Labyrinthe");
    }

    public void ChangerVitesse()
    {
        if (saisieVitesse.text != null)
        {
            gameManager.Vitesse = float.Parse(saisieVitesse.text);
        }
    }

    public void ChangerAcceleration()
    {
        if (saisieAcceleration.text != null)
        {
            gameManager.FacteurAcceleration = float.Parse(saisieAcceleration.text);
        }
    }
}
