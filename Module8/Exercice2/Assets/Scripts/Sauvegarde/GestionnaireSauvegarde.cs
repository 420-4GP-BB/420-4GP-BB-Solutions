using UnityEngine;
using System.IO;
using LitJson;
using System.Linq;
using UnityEngine.SceneManagement;

public class GestionnaireSauvegarde : MonoBehaviour
{

    private const string NOM_FICHIER = "sauvegarde.json";
    private const string OBJECTS_KEY = "objects";
    private const string SAVEID_KEY = "$saveID";

    private string _cheminFichier;    // Ne supporte qu'un seul fichier et il porte toujours le même nom.
    private JsonData objects = null;  // Les objets à charger une fois la scène est chargée

    // Dit si le fichier de sauvegarde existe
    public bool FichierExiste
    {
        get => !string.IsNullOrEmpty(_cheminFichier) && File.Exists(_cheminFichier);
    }

    // Start is called before the first frame update
    void Awake()
    {
        _cheminFichier = Path.Combine(Application.persistentDataPath, "sauvegarde.json");
    }

    public void SauvegarderPartie()
    {
        JsonData result = new JsonData();

        var allSaveables = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>();

        JsonData savedObjects = new JsonData();
        foreach (var saveable in allSaveables)
        {
            JsonData data = saveable.SavedData;
            data[SAVEID_KEY] = saveable.SaveID;
            savedObjects.Add(data);
        }
        result[OBJECTS_KEY] = savedObjects;

        // On écrit le fichier avec une indentation pour le rendre lisible
        var writer = new JsonWriter();
        writer.PrettyPrint = true;
        result.ToJson(writer);
        System.IO.File.WriteAllText(_cheminFichier, writer.ToString());
    }

    public void ChargerPartie(string nomScene)
    {
        if (!FichierExiste)
        {
            return;
        }

        string text = File.ReadAllText(_cheminFichier);

        objects = JsonMapper.ToObject(text)[OBJECTS_KEY];
        if (objects != null)
        {

            SceneManager.sceneLoaded += LoadAfter;  // La méthode sera appelée après le chargement de la scène
            SceneManager.LoadScene(nomScene, LoadSceneMode.Single);

        }
    }

    private void LoadAfter(Scene s, LoadSceneMode mode)
    {
        var allLoadables = Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToDictionary(o => o.SaveID, o => o);

        int nombreObjets = objects.Count;

        // Il faut restaurer les objets qui sont dans la sauvegarde
        for (int i = 0; i < nombreObjets; i++)
        {
            JsonData data = objects[i];
            string saveID = data[SAVEID_KEY].ToString();

            if (allLoadables.ContainsKey(saveID))
            {
                allLoadables[saveID].LoadFromData(data);
                allLoadables.Remove(saveID);                // On enlève car on a déjà traité cet objet
                                                            // Ceux qui restent seront détruits
            }
        }


        // Les objets qui ne sont pas dans la sauvegarde doivent être détruits
        foreach (var loadable in allLoadables.Values)
        {
            MonoBehaviour obj = loadable as MonoBehaviour;
            Destroy(obj.gameObject);   // L'objet ne doit plus être dans la scène
        }

        SceneManager.sceneLoaded -= LoadAfter;
    }
}
