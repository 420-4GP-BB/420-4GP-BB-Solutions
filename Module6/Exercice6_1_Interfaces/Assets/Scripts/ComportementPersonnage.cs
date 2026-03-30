using UnityEngine;

public class ComportementPersonnage : MonoBehaviour
{
    [SerializeField]
    private RotationBras scriptBrasGauche;

    [SerializeField]
    private RotationBras scriptBrasDroit;

    [SerializeField]
    private HochementTeteLocal scriptTete;

    public void AnimationsOnOff()
    {
        scriptBrasGauche.enabled = !scriptBrasGauche.enabled;
        scriptBrasDroit.enabled = !scriptBrasDroit.enabled;
        scriptTete.enabled = !scriptTete.enabled;
    }
}