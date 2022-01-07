using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur2 : MonoBehaviour
{
    [SerializeField] private float vitesse;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * vitesse * Time.fixedDeltaTime;
        float vertical = Input.GetAxis("Vertical") * vitesse * Time.fixedDeltaTime;
        transform.Translate(new Vector3(horizontal, 0, vertical));
    }
}
