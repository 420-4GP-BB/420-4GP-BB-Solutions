using System;
using UnityEngine;

public class ModeTurbo : MonoBehaviour
{
    private void Update()
    {
        Time.timeScale = 1;

        if (Input.GetKey(KeyCode.Tab))
        {
            // Acc�l�re le temps qui passe dans le jeu
            Time.timeScale = 10;
        }
        else if (Input.GetKey(KeyCode.P))
        {
            // Ralenti le temps du jeu
            Time.timeScale = 0.3f;
        }
    }
}