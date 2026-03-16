using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementJoueur : MonoBehaviour
{
    [SerializeField] 
    private float vitesseSaut = 5;

    private CharacterController characterController;
    private InputAction actionMouvement;
    private InputAction actionSaut;
    private InputAction actionCourse;

    private float vitesseY = 0;
    private Vector3 positionDepart;
    private Quaternion rotationDepart;

    void Start()
    {
        positionDepart = transform.position;
        rotationDepart = transform.rotation;
        characterController = GetComponent<CharacterController>();

        actionMouvement = InputSystem.actions.FindAction("Move");
        actionSaut = InputSystem.actions.FindAction("Jump");
        actionCourse = InputSystem.actions.FindAction("Sprint");    // Ex.6
    }

    void Update()
    {
        Vector2 inputMouvement = actionMouvement.ReadValue<Vector2>();
        Vector3 directionMouvement = new Vector3(inputMouvement.x, 0, inputMouvement.y);

        // Calcul la vitesse
        float vitesse = 10f;
        vitesse = ParametresJeu.Instance.vitesse;                   // Ex.6
        if (actionCourse.IsPressed()) 
        {
            vitesse *= ParametresJeu.Instance.facteurCourse;
        }

        // Dirige la vitesse selon axe local
        Vector3 vitesseLocale = vitesse * directionMouvement;
        vitesseLocale = transform.TransformDirection(vitesseLocale);

        // Calcule la vitesse en y (gravite + saut)
        if (characterController.isGrounded)
        {
            if (actionSaut.IsPressed()) vitesseY = vitesseSaut;
            else vitesseY = 0;
        }
        else
        {
            vitesseY += Physics.gravity.y * Time.deltaTime;
        }

        // Deplace le joueur
        Vector3 vitesseApplique = vitesseLocale + new Vector3(0, vitesseY, 0);
        characterController.Move(vitesseApplique * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Objectif"))
        {
            characterController.enabled = false;
            transform.position = positionDepart;
            transform.rotation = rotationDepart;
            characterController.enabled = true;
        }
    }
}