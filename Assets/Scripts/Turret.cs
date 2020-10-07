using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IBuyable, IUpgradable
{
    public float costBuy;
    public float costUpgrade;

    public bool Upgraded { get; set;}

    // Start is called before the first frame update
    void Start()
    {
        Upgraded = false;
    }

    public void UpgradeTurret(float playerGolds)
    {
        if(playerGolds >= costUpgrade)
        {
            Upgraded = true;
        }
    }

}
