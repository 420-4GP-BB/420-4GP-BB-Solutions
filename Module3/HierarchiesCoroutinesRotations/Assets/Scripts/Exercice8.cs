using UnityEngine;

// Script qui deplace la tete de gauche a droite
public class Exercice8 : MonoBehaviour
{
    [SerializeField]
    private float vitesseDeplacement = 1f;

    private Vector3 directionDeplacement = new Vector3(1f, 0f, 0f);

    void Update()
    {
        // Bouge la tete selon la direction de deplacement
        transform.position += vitesseDeplacement * directionDeplacement * Time.deltaTime;

        // Met a jour la direction de deplacement
        if (transform.position.x < -0.2f) 
        {
            directionDeplacement = new Vector3(1f, 0f, 0f);
        }
        else if (transform.position.x > 0.2f)
        {
            directionDeplacement = new Vector3(-1f, 0f, 0f);
        }
    }
}