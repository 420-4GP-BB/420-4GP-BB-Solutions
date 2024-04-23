using LitJson;

// Pris dans Unity Game Development Cookbook, Buttfield-Addison et al., O'Reilly, 2019.

public interface ISaveable
{
    string SaveID { get; }
    JsonData SavedData();
    void LoadFromData(JsonData data);
}