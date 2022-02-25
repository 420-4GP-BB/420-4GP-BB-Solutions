using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe qui permet de déplacer la balle avec des forces
/// 
/// Auteur: Éric Wenaas
/// </summary>
public class MouvementBalle : MonoBehaviour
{
    [SerializeField] private float forceBalle; // La force de la balle

    private Rigidbody _rbody;    // Le Rigidbody de la balle
    private float _horizontal;   // La valeur de la force à appliquer en horizontal
    private float _vertical;     // La valeur de la force à appliquer en vertical
    private Vector3 _positionInitiale; // La position initiale de la balle

    public Vector3 PositionInitiale  
    {
        set
        {
            _positionInitiale = value;
        }
        get
        {
            return _positionInitiale;
        }
    }

    private void Awake()
    {
        _rbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PositionInitiale = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        // Pour l'exercice 3
        if (transform.localPosition.y <= -2.0f)
        {
            ReplacerBalle();
        }
    }
    
    void FixedUpdate()
    {
        Vector3 directionForce = new Vector3(_horizontal, 0, _vertical);
        Vector3 forceApplicable = directionForce * forceBalle * Time.fixedDeltaTime;
        _rbody.AddForce(forceApplicable);
    }

    /**
     * Méthode qui replace la balle au bon endroit
     * 
     * Utilisée dans l'exercice 3
     */
    public void ReplacerBalle()
    {
        transform.localPosition = PositionInitiale;
        _rbody.velocity = Vector3.zero;
        _rbody.angularVelocity = Vector3.zero;
    }
}
