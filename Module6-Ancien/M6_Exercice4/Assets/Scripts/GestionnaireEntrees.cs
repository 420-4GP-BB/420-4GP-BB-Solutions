using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GestionnaireEntrees : MonoBehaviour
{
    private ICommande commandeProjectile;
    private ICommande commandeSaut;

    private void Start()
    {
        commandeProjectile = new CommandeProjectile(gameObject.GetComponent<LancementProjectile>());
        commandeSaut = new CommandeSaut(gameObject.GetComponent<MouvementJoueur>());
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        { 
            commandeSaut.ExecuterCommande();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            commandeProjectile.ExecuterCommande();
        }
    }
}
