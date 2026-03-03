using UnityEngine;
using UnityEngine.InputSystem;

public class VueSouris : MonoBehaviour
{
    private InputAction mouvementSouris;

    [SerializeField] private float vitesseRotation = 2;
    
    private float angle = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouvementSouris = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        var mouvement = mouvementSouris.ReadValue<Vector2>();

        transform.parent.Rotate(Vector3.up, mouvement.x * vitesseRotation * Time.deltaTime);

        // Par défaut, le Look a les axes de soursis
        angle += -mouvement.y * vitesseRotation * Time.deltaTime;
        angle = Mathf.Clamp(angle, -30, +30);
        
        transform.localEulerAngles = new Vector3(angle, 0, 0);
        print(transform.rotation.eulerAngles.x);
    }
}