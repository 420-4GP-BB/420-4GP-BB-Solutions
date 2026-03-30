using UnityEngine;
using UnityEngine.InputSystem;

public class GestionnaireJeu : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject objetClique = Utilitaires.DeterminerClic();
            if (objetClique == null) return;
            
            ComportementPoule comportementPoule = objetClique.GetComponent<ComportementPoule>();
            if (comportementPoule != null)
            {
                comportementPoule.Sauter();
            }

            ComportementPingouin comportementPingouin = objetClique.GetComponent<ComportementPingouin>();
            if (comportementPingouin != null)
            {
                comportementPingouin.RotationOnOff();
            }

            ComportementChat comportementChat = objetClique.GetComponent<ComportementChat>();
            if (comportementChat != null)
            {
                comportementChat.DebuterMouvement();
            }

            ComportementPersonnage comportementPersonnage = objetClique.GetComponent<ComportementPersonnage>();
            if (comportementPersonnage != null)
            {
                comportementPersonnage.AnimationsOnOff();
            }
            
        }
    }
}