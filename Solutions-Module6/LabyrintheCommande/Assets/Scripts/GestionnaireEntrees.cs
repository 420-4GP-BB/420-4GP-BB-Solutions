using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GestionnaireEntrees : MonoBehaviour
{
    [SerializeField] private GameObject joueur;

    private ICommand boutonGauche;
    private ICommand toucheEspace;
    // Start is called before the first frame update
    void Start()
    {
        boutonGauche = new CommandeProjectile(joueur.GetComponent<LancementProjectile>());
        toucheEspace = new CommandeSauter(joueur.GetComponent<MouvementCharacter>());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance().EnPause)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            boutonGauche.Executer();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            toucheEspace.Executer();
        }
    }
}
