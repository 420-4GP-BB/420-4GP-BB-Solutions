using UnityEngine;

public class ComportementPersonnageSolution : MonoBehaviour, ICliquable
{
    [SerializeField] private RotationBras scriptBras1;
    [SerializeField] private RotationBras scriptBras2;
    [SerializeField] private HochementTeteLocal scriptTete;

    public void AnimationsOnOff()
    {
        scriptBras1.enabled = !scriptBras1.enabled;
        scriptBras2.enabled = !scriptBras2.enabled;
        scriptTete.enabled = !scriptTete.enabled;
    }

    public void Clic()
    {
        AnimationsOnOff();
    }
}