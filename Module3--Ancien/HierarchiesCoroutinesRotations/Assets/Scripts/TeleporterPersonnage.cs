using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleporterPersonnage : MonoBehaviour
{
    [SerializeField] private GameObject terrain;

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            var position = Mouse.current.position.ReadValue();
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