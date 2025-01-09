using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurDetruit : MonoBehaviour, IMortel
{
    public void Mourir()
    {
        if (Application.isPlaying)
            Destroy(gameObject);
        else
            DestroyImmediate(gameObject);
    }
}
