using UnityEngine;

public class ComportementChatSolution : MonoBehaviour, ICliquable
{
    [SerializeField]
    private float vitesse = 10f;

    [SerializeField]
    private Transform destination;

    private Animator animator;
    private bool avance;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (destination.position == transform.position) return;

        if (avance)
        {
            Vector3 direction = (destination.position - transform.position).normalized;
            transform.position += direction * Time.deltaTime * vitesse;

            animator.SetFloat("State", 1);
            animator.SetFloat("Vert", 1);
        }
        else
        {
            animator.SetFloat("State", 0);
            animator.SetFloat("Vert", 0);
        }
    }

    public void DebuterMouvement()
    {
        avance = true;
        transform.LookAt(destination);
    }

    public void Clic()
    {
        DebuterMouvement();
    }
}