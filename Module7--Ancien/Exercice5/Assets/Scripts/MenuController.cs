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