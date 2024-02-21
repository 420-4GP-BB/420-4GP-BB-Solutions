using UnityEngine;

/// <summary>
/// Classe qui barre le curseur de souris. La touche escape permet de la libérer
/// 
/// Auteurs: Eric Wenaas, Nicolas Hurtubise
/// </summary>
public class CursorLock : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}