using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PointDeVie : MonoBehaviour
{

    [SerializeField] int pointsDeVieMax;

    private Animator _animator;

    private int _pointsActuels;
    // Start is called before the first frame update
    void Start()
    {
        _pointsActuels = pointsDeVieMax;
        _animator = GetComponent<Animator>();
    }
    
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Projectile")
        {
            _pointsActuels--;

            if (_pointsActuels == 0)
            {
                StartCoroutine(DetruireChampignon());
            }
            else
            {
//                Color couleur = GetComponent<Renderer>().material.color;
//                couleur = new Color(couleur.r / 2, couleur.g / 2, couleur.b / 2);
//                GetComponent<Renderer>().material.color = couleur;
            }
        }
    }

    public IEnumerator DetruireChampignon()
    {
        _animator.SetBool("Mort", true);
        MouvementEnnemi mouvement = GetComponent<MouvementEnnemi>();
        mouvement.Etat = mouvement.Mort; 
        yield return new WaitForSeconds(2.0f);
        // Destroy(gameObject);
    }

    public bool EstBlesse()
    {
        return _pointsActuels < pointsDeVieMax;
    }
}
