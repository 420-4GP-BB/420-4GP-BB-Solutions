using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void ChargerPartie()
    {
        GetComponent<GestionnaireSauvegarde>().ChargerPartie("Jeu");
    }

    public void NouvellePartie()
    {
        SceneManager.LoadScene("Jeu");
    }
}
