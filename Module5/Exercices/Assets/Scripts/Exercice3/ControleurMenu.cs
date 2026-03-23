using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControleurMenu : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField saisieVitesse;

    [SerializeField] 
    private TMP_InputField saisieAcceleration;

    public void Start()
    {
        saisieVitesse.text = ParametresJeu.Instance.vitesse.ToString();
        saisieAcceleration.text = ParametresJeu.Instance.facteurCourse.ToString();
    }

    public void Quitter()
    {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void ChargerJeu()
    {
        ChangerVitesse();
        ChangerAcceleration();
        // Changer pour le nom de la scene
        SceneManager.LoadScene("Exercice3Labyrinthe");
    }

    public void ChangerVitesse()
    {
        ParametresJeu.Instance.vitesse = int.Parse(saisieVitesse.text);
    }

    public void ChangerAcceleration()
    {
        ParametresJeu.Instance.facteurCourse = float.Parse(saisieAcceleration.text);
    }
}
