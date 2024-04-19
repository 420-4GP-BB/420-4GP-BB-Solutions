using LitJson;

public interface ISavable
{
    string SaveID { get; }    
    JsonData SavedData { get; }
    void LoadFromData(JsonData data);
}
