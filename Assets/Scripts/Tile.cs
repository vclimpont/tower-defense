using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector3 tilePosition;

    public bool HasTurret { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        tilePosition = transform.position;
        tilePosition.y += (transform.localScale.y / 2f);
        HasTurret = false;
    }

    void OnMouseOver()
    {
        PlayerController.OnTile = true;
        PlayerController.CurrentTile = this;
        PlayerController.TurretSpawnPosition = tilePosition;
    }
}
