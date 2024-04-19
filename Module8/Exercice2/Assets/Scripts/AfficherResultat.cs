using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfficherResultat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttendreEtAllerAuMenu(5.0f));
    }

    private IEnumerator AttendreEtAllerAuMenu(float temps)
    {
        yield return new WaitForSeconds(temps);
        SceneManager.LoadScene("Menu");
    }

}
