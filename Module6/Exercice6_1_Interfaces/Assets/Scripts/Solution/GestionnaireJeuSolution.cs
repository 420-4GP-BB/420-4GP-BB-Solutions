using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GestionnaireJeuSolution : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            var objet = Utilitaires.DeterminerClic();

            if (objet != null)
            {
                var objetCliquable = objet.GetComponent<ICliquable>();
                if (objetCliquable != null)
                {
                    objetCliquable.Clic();
                }
            }
        }
    }
}