using UnityEngine;
using UnityEngine.InputSystem;

public class VerrouillerSouris : MonoBehaviour
{
    void Start()
    {
        // La souris est invisible et ne peut pas sortir de Unity
        Cursor.lockState = CursorLockMode.Locked;

        // La souris est visible et peut sortir de Unity
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
