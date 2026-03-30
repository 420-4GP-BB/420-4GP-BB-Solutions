using UnityEngine;

public class ComportementPoule : MonoBehaviour
{
    [SerializeField]
    private GameObject plancher;

    [SerializeField]
    private float forceSaut = 5f;

    private bool toucheLeSol = true;

    private Rigidbody pouleRigidbody;
    private Animator animator;

    void Start()
    {
        pouleRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (toucheLeSol)
        {
            animator.SetFloat("State", 0);
            animator.SetFloat("Vert", 0);
        }
        else
        {
            animator.SetFloat("State", 1);
            animator.SetFloat("Vert", 1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == plancher)
        {
            toucheLeSol = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == plancher)
        {
            toucheLeSol = false;
        }
    }

    public void Sauter()
    {
        if (toucheLeSol)
        {
            pouleRigidbody.AddForce(new Vector3(0f, 1f, 0f) * forceSaut, ForceMode.Impulse);
        }
    }
}