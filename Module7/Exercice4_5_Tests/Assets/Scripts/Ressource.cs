using UnityEngine;

public class Ressource : MonoBehaviour, IPrecieux
{
    [HideInInspector]
    public int Valeur { get; set; }
}