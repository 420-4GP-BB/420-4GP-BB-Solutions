using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandeSauter : ICommande
{
    private MouvementJoueur _joueur;

    public CommandeSauter(MouvementJoueur joueur)
    {
        this._joueur = joueur;
    }

    public void executer()
    {
        _joueur.Sauter();
    }
}
