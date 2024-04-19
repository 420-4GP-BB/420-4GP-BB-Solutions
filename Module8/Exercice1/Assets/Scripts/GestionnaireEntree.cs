using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionnaireEntree : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GetComponent<GestionnaireSauvegarde>().SauvegarderPartie();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
