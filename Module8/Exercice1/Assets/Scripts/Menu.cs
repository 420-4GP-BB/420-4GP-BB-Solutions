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
        var allLoadables = Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToDictionary(o => o.SaveID, o => o);

        int nombreObjets = objects.Count;
        for (int i = 0; i < nombreObjets; i++)
        {
            JsonData data = objects[i];
            string saveID = data[SAVEID_KEY].ToString();

            if (allLoadables.ContainsKey(saveID))
            {
                allLoadables[saveID].LoadFromData(data);
            }
        }
        SceneManager.sceneLoaded -= LoadAfter;
    }

    public void NouvellePartie()
    {
        SceneManager.LoadScene("Jeu");
    }
}
