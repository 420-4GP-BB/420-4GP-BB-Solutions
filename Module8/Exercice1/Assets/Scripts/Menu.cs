using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private Button _boutonCharger;

    public void Start()
    {
        _boutonCharger = GameObject.Find("BoutonCharger").GetComponent<Button>();
        _boutonCharger.interactable = GetComponent<GestionnaireSauvegarde>().FichierExiste;
    }

    public void ChargerPartie()
    {
        GetComponent<GestionnaireSauvegarde>().ChargerPartie("Jeu");
    }

    public void NouvellePartie()
    {
        SceneManager.LoadScene("Jeu");
    }
}
