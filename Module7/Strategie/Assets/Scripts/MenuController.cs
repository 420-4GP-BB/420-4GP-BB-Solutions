using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Villageois villageois;

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