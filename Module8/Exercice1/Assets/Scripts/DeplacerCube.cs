using UnityEngine;

public class DeplacerCube : MonoBehaviour
{
    private const float TAUX_ACCELERATION = 1.1f;
    private const float DELAI_ACCELERATION = 10.0f;

    [SerializeField] private float _vitesse = 1.0f;
    [SerializeField] private float _tempsAccumule;

    void Update()
    {
        _tempsAccumule += Time.deltaTime;

        // Quand le délai expire, on accélère
        if (_tempsAccumule >= DELAI_ACCELERATION)
        {
            _vitesse *= TAUX_ACCELERATION;
            _tempsAccumule = 0;
        }

        // Déplacer le cube
        float vertical = Input.GetAxis("Vertical") * _vitesse * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * _vitesse * Time.deltaTime;
        transform.Translate(horizontal, vertical, 0);
    }
}
