using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IBuyable, IUpgradable
{
    public float costBuy;
    public float costUpgrade;

    public bool Upgraded { get; set;}

    public void UpgradeTurret()
    {
        if(!Upgraded)
        {
            Upgraded = true;
        }
    }
}
