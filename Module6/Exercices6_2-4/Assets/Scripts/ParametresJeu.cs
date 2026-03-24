public class ParametresJeu
{
    // Instance statique du singleton
    public static ParametresJeu Instance { get; } = new ParametresJeu();

    // Liste de parametres publiques
    public int vitesse = 15;
    public float facteurCourse = 1.5f;

    // Singleton, donc constructeur est prive
    private ParametresJeu() { }
}