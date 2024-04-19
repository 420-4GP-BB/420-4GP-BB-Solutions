using UnityEngine;
using LitJson;
using System.Linq;

public class Sauvegarder : MonoBehaviour
{
    private const string OBJECTS_KEY = "objects";
    private const string SAVEID_KEY = "$saveID";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SauvegarderPartie();
        }   
        
    }

    private void SauvegarderPartie()
    {
        string dossier = Application.persistentDataPath;
        string path = System.IO.Path.Combine(dossier, "sauvegarde.json");
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
        System.IO.File.WriteAllText(path, writer.ToString());        
    }
}
