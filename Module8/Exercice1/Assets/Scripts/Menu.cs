using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using LitJson;
using System.Linq;

public class Menu : MonoBehaviour
{
    private const string OBJECTS_KEY = "objects";
    private const string SAVEID_KEY = "$saveID";

    private JsonData objects = null;


    public void ChargerPartie()
    {
        var chemin = Path.Combine(Application.persistentDataPath, "sauvegarde.json");
        string text = File.ReadAllText(chemin);

        objects = JsonMapper.ToObject(text)[OBJECTS_KEY];

        if (objects != null)
        {
            SceneManager.sceneLoaded += LoadAfter;
            SceneManager.LoadScene("Jeu", LoadSceneMode.Single);
        }
    }

    private void LoadAfter(Scene s, LoadSceneMode mode)
    {
        var allLoadables = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<ISavable>();

        // O(n**2) peut-on faire mieux ?
        for (int i = 0; i < objects.Count; i++)
        {
            JsonData data = objects[i];
            string saveID = data[SAVEID_KEY].ToString();

            foreach (ISavable loadable in allLoadables)
            {
                if (loadable.SaveID == saveID)
                {
                    loadable.LoadFromData(data);
                    break;
                }
            }
        }
        SceneManager.sceneLoaded -= LoadAfter;
    }

    public void NouvellePartie()
    {
        SceneManager.LoadScene("Jeu");
    }
}
