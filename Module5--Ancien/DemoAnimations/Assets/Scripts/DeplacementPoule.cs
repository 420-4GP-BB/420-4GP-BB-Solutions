using UnityEngine;

public class DeplacementPoule : MonoBehaviour
{
    private Animator _Animator;
    [SerializeField] private float _vitesse = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float magnitudeVitesse = _vitesse;

        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var vitesse = magnitudeVitesse * direction;
        var deplacement = vitesse * Time.deltaTime;

        if (vitesse.magnitude > 0)
            transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);

        transform.position += deplacement;

        _Animator.SetFloat("Vitesse", vitesse.magnitude);
    }
}