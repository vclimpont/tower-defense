using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector3 tilePosition;

    // Start is called before the first frame update
    void Start()
    {
        tilePosition = transform.position;
        tilePosition.y += (transform.localScale.y / 2f);
    }

    void OnMouseOver()
    {
        Debug.Log(gameObject.name);
        PlayerController.OnTile = true;
        PlayerController.TurretSpawnPosition = tilePosition;
    }
}
