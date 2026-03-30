using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int dommages = 1;

    void Start()
    {
        // Detruire apres un certain temps
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision other)
    {
        PointsDeVie pointsDeVie = other.gameObject.GetComponent<PointsDeVie>();
        if (pointsDeVie != null)
        {
            pointsDeVie.RetirerPointsDeVie(dommages);
        }
        
        // XXX: Compatibilite avec la version du script pour l exercice 4
        // En vrai, en terminant l exercice 4 vous devriez avoir un seul script PointDeVies
        PointsDeVieV2 pointsDeVieV2 = other.gameObject.GetComponent<PointsDeVieV2>();
        if (pointsDeVieV2 != null)
        {
            pointsDeVieV2.RetirerPointsDeVie(dommages);
        }
        
        Destroy(gameObject);
    }
}
