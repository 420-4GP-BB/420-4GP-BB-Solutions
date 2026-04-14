using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModeTurbo : MonoBehaviour
{
    private void Update()
    {
        Time.timeScale = 1;

        if (Keyboard.current.tabKey.isPressed)
        {
            // Accélère le temps qui passe dans le jeu
            Time.timeScale = 10;
        }
        else if (Keyboard.current.pKey.isPressed)
        {
            // Ralenti le temps du jeu
            Time.timeScale = 0.3f;
        }
    }
}