using UnityEngine;
using UnityEngine.InputSystem;

public class VueSouris : MonoBehaviour
{
    [SerializeField]
    private float vitesseRotation = 5f;

    private float rotationMax = 30f;
    private float rotationMin = -30f;

    private InputAction actionSouris;
    private Transform parent;
    private float rotationApplique = 0f;

    void Start()
    {
        actionSouris = InputSystem.actions.FindAction("Look");
        parent = transform.parent;
    }

    void Update()
    {
        Vector2 inputSouris = actionSouris.ReadValue<Vector2>();

        // Rotation applique sur le joueur
        float rotationJoueur = inputSouris.x * vitesseRotation * Time.deltaTime;
        parent.Rotate(new Vector3(0f, rotationJoueur, 0f));

        // Rotation applique sur la camera
        float rotationCamera = -inputSouris.y * vitesseRotation * Time.deltaTime;
        rotationApplique += rotationCamera;

        // Limite la rotation
        if (rotationApplique >= rotationMax) rotationApplique = rotationMax;
        else if (rotationApplique <= rotationMin) rotationApplique = rotationMin;
        
        transform.localEulerAngles = new Vector3(rotationApplique, 0f, 0f);
    }
}