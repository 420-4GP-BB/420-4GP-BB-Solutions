using UnityEngine;
using LitJson;

public class SauvegardePointPatrouille : SauvegardeBase
{
    public override JsonData SavedData()
    {
        return SavedTransform;
    }

    public override void LoadFromData(JsonData data)
    {
        LoadTransformFromData(data);
    }
}