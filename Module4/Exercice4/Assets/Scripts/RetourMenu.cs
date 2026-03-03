using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RetourMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
        }
    }
}
