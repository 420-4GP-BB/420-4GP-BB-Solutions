internal class CommandeSaut : ICommande
{
    private MouvementJoueur joueur;

    public CommandeSaut(MouvementJoueur leJoueur)
    {
        joueur = leJoueur;
    }
    public void ExecuterCommande()
    {
        joueur.Sauter();
    }
}