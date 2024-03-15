using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurDetruit : MonoBehaviour, IMortel
{
    public void FaireMourir()
    {
        Destroy(gameObject);
    }
}
