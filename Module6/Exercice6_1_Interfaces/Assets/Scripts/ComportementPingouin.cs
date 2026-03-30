using UnityEngine;

public class ComportementPingouin : MonoBehaviour
{
    [SerializeField] 
    private float vitesseAngulaire = 120f;

    private Animator animator;
    private bool rotate = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (rotate)
        {
            transform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * vitesseAngulaire);
        }
    }

    public void RotationOnOff()
    {
        rotate = !rotate;
        
        if (!rotate)
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
}