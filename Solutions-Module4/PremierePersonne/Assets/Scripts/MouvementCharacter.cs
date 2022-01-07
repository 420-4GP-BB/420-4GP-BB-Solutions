using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementCharacter : MonoBehaviour
{
    [SerializeField] private float vitesse;
    [SerializeField] private GameObject plancherBoite;

    private float gravity = 9.8f;
    private CharacterController _controller;
    private Vector3 _positionInitiale;
    private Quaternion _rotationInitiale;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _positionInitiale = transform.localPosition;
        _rotationInitiale = transform.localRotation;

    }

    private void FixedUpdate()
    {
        float vitesseReelle = vitesse;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vitesseReelle *= 1.5f;
        }

        float horizontal = Input.GetAxis("Horizontal") * vitesseReelle;
        float vertical = Input.GetAxis("Vertical") * vitesseReelle;


        float y = 0;
        if (_controller.isGrounded)
        {
            // Peut sauter
            if (Input.GetButton("Jump"))
            {
                y = 20 * gravity;
            }
        } 
        else
        {
            y = gravity * -1;
        }


        Vector3 deplacement = new Vector3(horizontal, y, vertical) * Time.fixedDeltaTime;
        deplacement = transform.TransformDirection(deplacement);
        _controller.Move(deplacement);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject == plancherBoite)
        {
            StartCoroutine(ReplacerJoueur());
        } 
        else if (hit.gameObject.CompareTag("Ennemi"))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }

    private IEnumerator ReplacerJoueur()
    {
        _controller.enabled = false;
        transform.localPosition = _positionInitiale;
        transform.localRotation = _rotationInitiale;
        _controller.enabled = true;
        yield return new WaitForSeconds(2.0f);
    }

}
