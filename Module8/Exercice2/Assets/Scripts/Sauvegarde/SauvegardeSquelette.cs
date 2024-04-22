using UnityEngine;
using LitJson;
using System;

public class SauvegarderSquelette : MonoBehaviour,
                                    ISaveable,
                                    ISerializationCallbackReceiver
{
    private Transform[] garderPoints;

    [SerializeField]
    private string _saveID;

    public string SaveID
    {
        get => _saveID;
        set => _saveID = value;
    }

    public void OnAfterDeserialize()
    {
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
            data["mouvement"] = JsonUtility.ToJson(GetComponent<MouvementSquelette>());
            data["points_vie"] = JsonUtility.ToJson(GetComponent<PointsDeVie>());
            data["localPosition"] = JsonUtility.ToJson(transform.localPosition);
            data["localRotation"] = JsonUtility.ToJson(transform.localRotation);
            data["localScale"] = JsonUtility.ToJson(transform.localScale);
            return data;
        }
    }

    public void LoadFromData(JsonData data)
    {
        // PATCH: On reconstruit l'objet EtatPatrouille car les points ont été détruits.
        // Même l'indice doit être reconstruit.
        Transform[] points = GetComponent<MouvementSquelette>().PointsPatrouille;
        garderPoints = points.Clone() as Transform[];
        JsonUtility.FromJsonOverwrite(data["mouvement"].ToString(), GetComponent<MouvementSquelette>());
        GetComponent<MouvementSquelette>().PointsPatrouille = garderPoints;

        JsonUtility.FromJsonOverwrite(data["points_vie"].ToString(), GetComponent<PointsDeVie>());
        transform.localPosition = JsonUtility.FromJson<Vector3>(data["localPosition"].ToString());
        transform.localRotation = JsonUtility.FromJson<Quaternion>(data["localRotation"].ToString());
        transform.localScale = JsonUtility.FromJson<Vector3>(data["localScale"].ToString());
        int indice = 3;
        GetComponent<MouvementSquelette>().Patrouille =
            new EtatPatrouille(GetComponent<MouvementSquelette>(), GameObject.Find("Joueur"), garderPoints, indice);
    }
}
