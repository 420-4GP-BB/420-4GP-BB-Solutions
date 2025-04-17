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
        int idStrategie = 0;

        if (villageois.strategieChoix is StrategieChoixHasard)
            idStrategie = 0;
        else if(villageois.strategieChoix is StrategieChoixPlusProche)
            idStrategie = 1;
        else if (villageois.strategieChoix is StrategieChoixEquilibre)
            idStrategie = 2;

        PlayerPrefs.SetInt("StrategieChoixRessource", idStrategie);
    }

    public void ChargerStrategie()
    {
        // 0 : choix au hasard par d�faut (si on n'a jamais enregistr� de strat�gie avant)
        int id = PlayerPrefs.GetInt("StrategieChoixRessource", 0);

        print("Strat�gie recharg�e: " + id);

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