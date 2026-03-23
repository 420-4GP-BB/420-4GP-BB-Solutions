using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RetourMenu : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Exercice3Menu");
        }
    }
}
