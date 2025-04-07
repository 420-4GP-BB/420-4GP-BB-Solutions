using UnityEngine;

public class Piege : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Villageois villageois))
        {
            villageois.PerdreOr(10);
            Destroy(this.gameObject);
        }
    }
}
