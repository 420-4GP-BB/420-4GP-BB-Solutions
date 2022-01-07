public class CommandeProjectile : ICommand
{
    private LancementProjectile sujet;

    public CommandeProjectile(LancementProjectile sujet)
    {
        this.sujet = sujet;
    }
    
    public void Executer()
    {
        sujet.LancerProjectile();
    }
}
