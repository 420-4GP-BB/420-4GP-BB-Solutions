using UnityEngine;
using UnityEngine.InputSystem;

// Script qui teleporte le personnage a l endroit clique
public class Exercice1_3 : MonoBehaviour
{
    [SerializeField] 
    private GameObject terrain;

    void Update()
    {
        // Si le bouton gauche de la souris a ete clique
        if (Mouse.current.leftButton.isPressed)
        {
            // Position de la souris
            Vector2 positionSouris = Mouse.current.position.ReadValue();

            // Laser du centre de la camera a la position de la souris
            Ray ray = Camera.main.ScreenPointToRay(positionSouris);
            
            // Si le laser est rentre en contact avec un element
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == terrain)
                {
                    // Met a jour la position du personnage au point de contact
                    transform.position = hit.point;
                }
            }
        }
    }
}