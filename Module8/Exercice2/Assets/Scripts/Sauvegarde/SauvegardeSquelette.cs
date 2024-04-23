using UnityEngine;
using LitJson;
using System;

public class SauvegarderSquelette : SauvegardeBase
{
    private Transform[] garderPoints;

    public override JsonData SavedData()
    {
        JsonData data = SavedTransform;
        data["mouvement"] = JsonUtility.ToJson(GetComponent<MouvementSquelette>());
        data["points_vie"] = JsonUtility.ToJson(GetComponent<PointsDeVie>());
        return data;
    }

    public override void LoadFromData(JsonData data)
    {
        // PATCH: On reconstruit l'objet EtatPatrouille car les points ont été détruits.
        // Même l'indice doit être reconstruit.
        Transform[] points = GetComponent<MouvementSquelette>().PointsPatrouille;
        garderPoints = points.Clone() as Transform[];
        JsonUtility.FromJsonOverwrite(data["mouvement"].ToString(), GetComponent<MouvementSquelette>());
        GetComponent<MouvementSquelette>().PointsPatrouille = garderPoints;

        JsonUtility.FromJsonOverwrite(data["points_vie"].ToString(), GetComponent<PointsDeVie>());

        LoadTransformFromData(data);

        GetComponent<MouvementSquelette>().Patrouille =
            new EtatPatrouille(GetComponent<MouvementSquelette>(), GameObject.Find("Joueur"), garderPoints);
    }
}