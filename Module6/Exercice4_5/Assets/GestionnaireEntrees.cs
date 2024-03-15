using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireEntrees : MonoBehaviour
{
    private CommandeSauter _commandeSauter;
    private CommandeProjectile _commandeProjectile;
    
    // Start is called before the first frame update
    void Start()
    {
        _commandeSauter = new CommandeSauter(GetComponent<MouvementJoueur>());
        _commandeProjectile = new CommandeProjectile(GetComponent<LancementProjectile>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _commandeSauter.executer();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _commandeProjectile.executer();
        }

    }
}
