using UnityEngine;

public class Utilitaires 
{
    public static Vector3? DeterminerClic(Collider colliderCible)
    {
        Vector3 positionSouris = Input.mousePosition;
        Vector3? pointClique = null;

        // Trouver le lien avec la caméra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet touché est le plan.
            if (hit.collider == colliderCible)
            {
                // Le vecteur est initialise ici car le clic est sur le plan
                pointClique = hit.point;
            }
        }
        return pointClique;
    }
}

