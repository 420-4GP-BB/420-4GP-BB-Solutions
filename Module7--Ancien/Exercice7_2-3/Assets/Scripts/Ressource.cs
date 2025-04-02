using UnityEngine;

public enum TypeRessource
{
    Or,
    Plante,
    Roche
}

public class Ressource : MonoBehaviour
{
    [SerializeField] private TypeRessource type;
    [SerializeField] private int valeur;

    public TypeRessource Type
    {
        get => type;
    }

    public int Valeur
    {
        get => valeur;
    }
}