using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterPersonnage : MonoBehaviour
{
    [SerializeField] private GameObject terrain;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var position = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(position);

            var hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject == terrain)
                {
                    transform.position = hit.point;
                    
                    break;
                }
            }
        }
    }
}