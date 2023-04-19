using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandeProjectile : ICommande
{
    private LancementProjectile _lancementProjectile;

    public CommandeProjectile(LancementProjectile lancementProjectile)
    {
        this._lancementProjectile = lancementProjectile;
    }

    public void executer()
    {
        _lancementProjectile.LancerProjectile();
    }
}

