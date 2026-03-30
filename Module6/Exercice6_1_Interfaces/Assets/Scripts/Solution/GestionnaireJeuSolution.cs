using UnityEngine;
using UnityEngine.InputSystem;

public class GestionnaireJeuSolution : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject objetClique = Utilitaires.DeterminerClic();
            if (objetClique == null) return;
            
            ICliquable objetCliquable = objetClique.GetComponent<ICliquable>();
            if (objetCliquable != null)
            {
                objetCliquable.Clic();
            }
        }
    }
}