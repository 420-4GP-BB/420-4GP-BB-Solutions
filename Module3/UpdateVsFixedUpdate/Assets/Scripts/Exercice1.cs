using UnityEngine;
using TMPro;

public class Exercice1 : MonoBehaviour
{
    [SerializeField] private TMP_Text _nombreClics;
    [SerializeField] private TMP_Text _velociteActuelle;

    private Rigidbody _rbCube;
    private int _clics = 0;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = -1;
        _rbCube = GetComponent<Rigidbody>();
        _nombreClics.text = _clics.ToString();
        _velociteActuelle.text = _rbCube.velocity.magnitude.ToString("N6");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clics++;
            _nombreClics.text = _clics.ToString();
        }

        _rbCube.AddForce(-Physics.gravity, ForceMode.Acceleration);
        _velociteActuelle.text = _rbCube.velocity.magnitude.ToString("N6");
    }

    //void FixedUpdate()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        _clics++;
    //        _nombreClics.text = _clics.ToString();
    //    }

    //    _rbCube.AddForce(-Physics.gravity, ForceMode.Acceleration);
    //    _velociteActuelle.text = _rbCube.velocity.magnitude.ToString("N6");
    //}
}
