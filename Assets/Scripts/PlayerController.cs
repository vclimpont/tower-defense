using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerController
{
    public static int Gold { get; set; }
    public static int Health { get; set; }
    public static Vector3 TurretSpawnPosition { get; set; }
    public static Vector3 TurretSpawnRotation { get; set; }

    public static Tile CurrentTile { get; set; }

    public static Turret TurretToUpgrade { get; set; }

    public static bool Buying { get; set; }
    public static bool OnTile { get; set; }
}
