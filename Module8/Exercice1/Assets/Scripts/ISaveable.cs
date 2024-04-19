using LitJson;

// Ajouter référence

public interface ISaveable
{
    string SaveID { get; }    
    JsonData SavedData { get; }
    void LoadFromData(JsonData data);
}
