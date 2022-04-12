using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionMunitions : MonoBehaviour
{
    [SerializeField] private Text  txtMunitions;
    [SerializeField] private LancementProjectile lancerProjectile;

    public void Start()
    {
        txtMunitions.text = lancerProjectile.QuantiteProjectile.ToString();
        lancerProjectile.ChangementNombreProjectilesHandler += AjusterChampMunitions;
    }

    public void AjusterChampMunitions()
    {
        txtMunitions.text = lancerProjectile.QuantiteProjectile.ToString();
    }
}
