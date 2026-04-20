using UnityEngine;

public enum TypeRessource
{
    Or,
    Plante,
    Roche
}

public class Ressource : MonoBehaviour
{
    public TypeRessource type;
    public int valeur;
}