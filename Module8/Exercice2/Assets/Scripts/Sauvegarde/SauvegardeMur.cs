using UnityEngine;
using LitJson;

public class SauvegarderMur : SauvegardeBase
{
    public override JsonData SavedData()
    {
        JsonData data = new JsonData();
        data["points_vie"] = JsonUtility.ToJson(GetComponent<PointsDeVie>());
        return data;
    }

    public override void LoadFromData(JsonData data)
    {
        JsonUtility.FromJsonOverwrite(data["points_vie"].ToString(), GetComponent<PointsDeVie>());
    }
}