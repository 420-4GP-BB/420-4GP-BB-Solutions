using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireJeuSolution : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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