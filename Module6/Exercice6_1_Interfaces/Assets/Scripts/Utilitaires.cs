using System.Collections;
using UnityEngine;

public class Utilitaires
{
    public static GameObject DeterminerClic()
    {
        Vector3 positionSouris = Input.mousePosition;
        GameObject objetSelectionne = null;

        // Trouver le lien avec la caméra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            objetSelectionne = hit.collider.gameObject;
        }

        return objetSelectionne;
    }
}