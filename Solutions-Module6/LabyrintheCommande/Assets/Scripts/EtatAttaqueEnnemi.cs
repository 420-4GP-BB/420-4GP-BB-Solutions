using UnityEngine;

public class EtatAttaqueEnnemi : EtatMouvementEnnemi
{
    private GameObject _joueur;
    public EtatAttaqueEnnemi(MouvementEnnemi ennemi, GameObject joueur) : base(ennemi, joueur)
    {
        _joueur = joueur;
    }

    public override void Deplacer()
    {
        if (JoueurVisible())
        { 
            Agent.destination = _joueur.transform.position;
        }
        else
        {
            Mouvement.Etat = Mouvement.Patrouille;
        }
    }
}