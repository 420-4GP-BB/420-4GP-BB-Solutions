using UnityEngine;
using LitJson;

public class SauvegarderJoueur : SauvegardeBase
{
    public override JsonData SavedData()
    {
        return SavedTransform;
    }

    public override void LoadFromData(JsonData data)
    {
        // IMPORTANT: Puisqu'il y a un CharacterController, on ne peut pas modifier la
        // transform sans le d�sactiver et r�activer.
        // On aurait Un probl�me similaire avec un NavMesh.
        GetComponent<CharacterController>().enabled = false;
        LoadTransformFromData(data);
        GetComponent<CharacterController>().enabled = true;
    }
}