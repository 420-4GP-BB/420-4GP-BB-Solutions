public abstract class EtatEnnemi
{
    public ComportementEnnemi sujet;

    public EtatEnnemi(ComportementEnnemi _sujet)
    {
        sujet = _sujet;
    }

    public virtual void Entrer() { }
    public virtual void Sortir() { }
    public abstract void Executer(float deltaTime);
}
