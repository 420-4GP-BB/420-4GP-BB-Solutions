using UnityEngine;

public class RotationBras : MonoBehaviour
{
    [SerializeField] 
    private float vitesseRotation = 180;

    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * vitesseRotation);
    }
}