using LitJson;
using UnityEngine;

public class SauverCube : MonoBehaviour, 
                          ISaveable, 
                          ISerializationCallbackReceiver
{
    private const string LOCAL_POSITION_KEY = "localPosition";
    private const string LOCAL_ROTATION_KEY = "localRotation";
    private const string LOCAL_SCALE_KEY = "localScale";

    [HideInInspector]
    [SerializeField] private string _saveID;


    public string SaveID
    {
        set => _saveID = value;
        get => _saveID;
    }

    public void OnBeforeSerialize()
    {
        if (string.IsNullOrEmpty(_saveID)) 
        { 
            _saveID = System.Guid.NewGuid().ToString();
        }
    }

    public void OnAfterDeserialize()
    {
        // Rien � faire
    }

    public JsonData SavedData => BuildData();

    public void LoadFromData(JsonData data)
    {
        JsonUtility.FromJsonOverwrite(data["deplacer"].ToString(), GetComponent<DeplacerCube>());
        transform.localPosition = JsonUtility.FromJson<Vector3>(data[LOCAL_POSITION_KEY].ToString());
        transform.localRotation = JsonUtility.FromJson<Quaternion>(data[LOCAL_ROTATION_KEY].ToString());
        transform.localScale = JsonUtility.FromJson<Vector3>(data[LOCAL_SCALE_KEY].ToString());
    }


    private JsonData BuildData()
    {
        var result = new JsonData();
        result["deplacer"] = JsonUtility.ToJson(GetComponent<DeplacerCube>());
        result[LOCAL_POSITION_KEY] = JsonUtility.ToJson(transform.localPosition);
        result[LOCAL_ROTATION_KEY] = JsonUtility.ToJson(transform.localRotation);
        result[LOCAL_SCALE_KEY] = JsonUtility.ToJson(transform.localScale);
        return result;
    }
}
