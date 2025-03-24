using UnityEngine;

public class ComportementPingouin : MonoBehaviour
{
    private Animator _animator;
    private bool _rotation;
    
    private Quaternion _rotationInitiale;
    [SerializeField] private float _vitesseAngulaire = 120;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rotationInitiale = transform.rotation;
    }

    private void Update()
    {
        if (!_rotation)
        {
            transform.rotation = _rotationInitiale;
            return;
        }
        
        transform.Rotate(Vector3.up, _vitesseAngulaire * Time.deltaTime);
    }

    public void RotationOnOff()
    {
        _rotation = !_rotation;
        
        if (!_rotation)
        {
            _animator.SetFloat("State", 0);
            _animator.SetFloat("Vert", 0);
        }
        else
        {
            _animator.SetFloat("State", 1);
            _animator.SetFloat("Vert", 1);
        }
    }
}