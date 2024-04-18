using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauvegarder : MonoBehaviour
{
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
        var dossier = Application.persistentDataPath;
        var path = System.IO.Path.Combine(dossier, "partieTest.json");
        string contenu = "Allo";
        System.IO.File.WriteAllText(path, contenu);        
    }
}
