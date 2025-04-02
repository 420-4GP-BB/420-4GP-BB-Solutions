using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private Villageois villageois;

    private void Start()
    {
        villageois = GameObject.FindObjectOfType<Villageois>();

        ChargerStrategie();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("volume", 0.8f); // 80% de volume
        PlayerPrefs.SetInt("difficulte", 3); // Difficulté 3 sur 10
        PlayerPrefs.SetString("nom", "Jimmy"); // Nom du joueur
    }

    public void ChargerStrategie()
    {
        // 0 : choix au hasard par défaut (si on n'a jamais enregistré de stratégie avant)
        int id = PlayerPrefs.GetInt("StrategieChoixRessource", 0);

        print("Stratégie rechargée: " + id);

        if (id == 0)
        {
            ChoixHasard();
        }
        else if (id == 1)
        {
            ChoixPlusProche();
        }
        else
        {
            ChoixEquilibre();
        }
    }

    public void ChoixHasard()
    {
        villageois.ChangerStrategieChoix(new StrategieChoixHasard());
    }

    public void ChoixPlusProche()
    {
        villageois.ChangerStrategieChoix(new StrategieChoixPlusProche());
    }

    public void ChoixEquilibre()
    {
        villageois.ChangerStrategieChoix(new StrategieChoixEquilibre());
    }
}