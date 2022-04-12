using UnityEngine;

public class EtatPatrouilleEnnemi : EtatMouvementEnnemi
{
    private int _indiceObjectifs;
    private Vector3 _objectif;
    
    public EtatPatrouilleEnnemi(MouvementEnnemi ennemi, GameObject joueur) : base(ennemi, joueur)
    {
        _indiceObjectifs = 0;
        Agent.speed = GameManager.Instance().VitesseEnnemi;
        _objectif = Mouvement.Waypoints[_indiceObjectifs].transform.position;
        Agent.destination = _objectif;
    }

    public override  void Deplacer()
    {
        if (Mouvement.EstBlesse() && JoueurVisible())
        {
            Mouvement.Etat = Mouvement.Attaque;
        }
        else
        {
            Vector3 position = Mouvement.transform.position;

            if (Vector3.Distance(position, _objectif) <= 0.1f)
            {
                _indiceObjectifs = (_indiceObjectifs + 1) % Mouvement.Waypoints.Length;
                _objectif = Mouvement.Waypoints[_indiceObjectifs].transform.position;
            }
            Agent.destination = _objectif;
        }
    }
}
