using UnityEngine;
using LitJson;

public class SauvegarderMur : MonoBehaviour,
                              ISaveable,
                              ISerializationCallbackReceiver
{
    [HideInInspector]
    [SerializeField]
    private string _saveID;


    public string SaveID
    {
        get => _saveID;
        set => _saveID = value;
    }

    public void OnAfterDeserialize()
    {
        // Rìen à faire
    }

    public void OnBeforeSerialize()
    {
        if (string.IsNullOrEmpty(_saveID))
        {
            _saveID = System.Guid.NewGuid().ToString();
        }
    }

    public JsonData SavedData
    {
        get
        {
            JsonData data = new JsonData();
            data["points_vie"] = JsonUtility.ToJson(GetComponent<PointsDeVie>());
            return data;
        }
    }

    public void LoadFromData(JsonData data)
    {
        JsonUtility.FromJsonOverwrite(data["points_vie"].ToString(), GetComponent<PointsDeVie>());
    }
}
