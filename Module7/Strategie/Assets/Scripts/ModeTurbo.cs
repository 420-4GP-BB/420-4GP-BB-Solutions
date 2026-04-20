using UnityEngine;
using UnityEngine.InputSystem;

public class ModeTurbo : MonoBehaviour
{
    void Update()
    {
        Time.timeScale = 1;

        if (Keyboard.current.tabKey.isPressed)
        {
            Time.timeScale = 10;
        }
        else if (Keyboard.current.pKey.isPressed)
        {
            Time.timeScale = 0.3f;
        }
    }
}