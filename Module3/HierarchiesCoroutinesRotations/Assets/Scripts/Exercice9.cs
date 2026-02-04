using UnityEngine;

// Script qui deplace la tete de gauche a droite avec la position locale
public class Exercice9 : MonoBehaviour
{
    [SerializeField]
    private float vitesseDeplacement = 1f;

    private Vector3 directionDeplacement = new Vector3(1f, 0f, 0f);

    void Update()
    {
        // Bouge la tete avec la position LOCALE selon la direction de deplacement
        transform.localPosition += vitesseDeplacement * directionDeplacement * Time.deltaTime;

        if (transform.localPosition.x < -0.2f)
        {
            directionDeplacement = new Vector3(1f, 0f, 0f);
        }
        else if (transform.localPosition.x > 0.2f)
        {
            directionDeplacement = new Vector3(-1f, 0f, 0f);
        }
    }
}