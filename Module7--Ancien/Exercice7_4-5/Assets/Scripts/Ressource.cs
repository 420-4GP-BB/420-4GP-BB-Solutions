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
    public int Valeur;

    public TypeRessource Type
    {
        get => type;
    }
}