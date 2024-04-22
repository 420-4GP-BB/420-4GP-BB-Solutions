using UnityEngine;
using LitJson;

public class SauvegardePointPatrouille : MonoBehaviour,
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
            data["localPosition"] = JsonUtility.ToJson(transform.localPosition);
            data["localRotation"] = JsonUtility.ToJson(transform.localRotation);
            data["localScale"] = JsonUtility.ToJson(transform.localScale);
            return data;
        }
    }

    public void LoadFromData(JsonData data)
    {
        transform.localPosition = JsonUtility.FromJson<Vector3>(data["localPosition"].ToString());
        transform.localRotation = JsonUtility.FromJson<Quaternion>(data["localRotation"].ToString());
        transform.localScale = JsonUtility.FromJson<Vector3>(data["localScale"].ToString());
    }
}

