using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CouleurHasard : MonoBehaviour
{
    [SerializeField] private Material[] couleurs;

    private float tempsParCouleur = 3.0f;
    private float tempsEcoule = 0;

    private int numeroCouleur = -1; // Changé dès le Start()
    private Renderer _renderer;

    public int NumeroCouleur
    {
        get => numeroCouleur;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        NouvelleCouleur();
    }

    void Update()
    {
        tempsEcoule += Time.deltaTime;

        if (tempsEcoule > tempsParCouleur)
        {
            tempsEcoule = 0;
            NouvelleCouleur();
        }
    }

    private void NouvelleCouleur()
    {
        int ancienneCouleur = numeroCouleur;

        do
        {
            numeroCouleur = Random.Range(0, couleurs.Length);
        } while (ancienneCouleur == numeroCouleur);

        _renderer.material = couleurs[numeroCouleur];
    }
}