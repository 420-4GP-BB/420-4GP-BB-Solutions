using UnityEngine;

public class MurBrisable : MonoBehaviour, IBrisable
{
    public void Detruire()
    {
        Destroy(gameObject);
    }
}
