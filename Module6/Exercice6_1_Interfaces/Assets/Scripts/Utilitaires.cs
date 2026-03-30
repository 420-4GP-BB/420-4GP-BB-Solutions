using UnityEngine;
using UnityEngine.InputSystem;

public class Utilitaires : MonoBehaviour
{
    public static GameObject DeterminerClic()
    {
        Vector2 positionSouris = Mouse.current.position.ReadValue();
        GameObject objetSelectionne = null;

        Ray ray = Camera.main.ScreenPointToRay(positionSouris);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            objetSelectionne = hit.collider.gameObject;
        }

        return objetSelectionne;
    }
}