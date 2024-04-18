using System.Text;
using System.Text.Json;
using UnityEngine;

public class Sauvegarde : MonoBehaviour
{

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
        string nomFichier = FichierPourSauvegardes("partie.json");

        GameObject player = GameObject.Find("Joueur");
        StringBuilder json = new StringBuilder();
        json.Append("{\n");
        json.Append("\t\"joueur\": {\n");
        json.Append("\t\t\"position\": {\n");
        json.Append("\t\t\t\"x\": " + player.transform.position.x + ",\n");
        json.Append("\t\t\t\"y\": " + player.transform.position.y + ",\n");
        json.Append("\t\t\t\"z\": " + player.transform.position.z + "\n");
        json.Append("\t\t}\n");
        json.Append("\t\t" + player.GetComponent<MouvementJoueur>().SaveToString() + "\n");
        json.Append("\t}\n");
        json.Append("}\n");
        Debug.Log(json);

        System.IO.File.WriteAllText(nomFichier, json.ToString());
    }

    public string FichierPourSauvegardes(string nomFichier)
    {
        var dossier = Application.persistentDataPath;
        var chemin = System.IO.Path.Combine(dossier, nomFichier);
        return chemin;
    }
}
