using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var objet = Utilitaires.DeterminerClic();

            if (objet != null)
            {
                var comportementPoule = objet.GetComponent<ComportementPoule>();
                if (comportementPoule != null)
                {
                    comportementPoule.Sauter();
                }

                var comportementPingouin = objet.GetComponent<ComportementPingouin>();
                if (comportementPingouin != null)
                {
                    comportementPingouin.RotationOnOff();
                }

                var comportementChat = objet.GetComponent<ComportementChat>();
                if (comportementChat != null)
                {
                    comportementChat.DebuterAvancer();
                }
                
                var comportementPersonnage = objet.GetComponent<ComportementPersonnage>();
                if (comportementPersonnage != null)
                {
                    comportementPersonnage.AnimationsOnOff();
                }
            }
        }
    }
}