using UnityEngine;

public interface IBrisable
{
    // Dans le cas d'un Squelette, le code de cette méthode serait : 
    //             ChangerEtat(new EtatMort(this));
    // Dans le cas du MurBrisable, on va avoir simplement
    //             Destroy(gameObject);
    public void Detruire();
}
