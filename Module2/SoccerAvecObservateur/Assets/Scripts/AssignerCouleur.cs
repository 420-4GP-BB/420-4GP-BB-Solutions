using UnityEngine;

[ExecuteInEditMode]
public class AssignerCouleur : MonoBehaviour
{
    [SerializeField] private Material material;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform enfant in transform)
        {
            enfant.GetComponent<Renderer>().material = material;
        }
    }
}