using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleurLancement : MonoBehaviour
{
    [SerializeField] private Text txtNombreBalles;
    [SerializeField] private LancerBalle balle;

    private int nombreBalles = 2;

    // Start is called before the first frame update
    void Start()
    {
        txtNombreBalles.text = "Nombre de balles: " + nombreBalles.ToString();
        balle.LancerReussiHandler += DecrementerBalles;
    }
    
    public void DecrementerBalles()
    {
        nombreBalles--;
        txtNombreBalles.text = "Nombre de balles: " + nombreBalles.ToString();

        if (nombreBalles == 0)
        {

            // Instruction de pré-compilation. Une seule branche est compilée selon
            // le contexte
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

    }
}
