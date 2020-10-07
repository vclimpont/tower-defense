using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawnTurret : MonoBehaviour
{
    public GameObject cannonPreview;
    public GameObject cannonPrefab;
    public GameObject ftPreview;
    public GameObject ftPrefab;
    public GameObject ionicPreview;
    public GameObject ionicPrefab;

    private GameObject currentTurret;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(PlayerController.Buying)
        {
            if(!PlayerController.OnTile)
            {
                PlayerController.TurretSpawnPosition = GetMousePositionInWorld();
            }

            currentTurret.transform.position = PlayerController.TurretSpawnPosition;
        }
    }

    Vector3 GetMousePositionInWorld()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 15));
        return mousePosition;
    }

    public void SpawnTurret(string turretType)
    {
        PlayerController.Buying = true;
        PlayerController.TurretSpawnPosition = GetMousePositionInWorld();

        switch(turretType)
        {
            case "Cannon":
                currentTurret = Instantiate(cannonPreview, PlayerController.TurretSpawnPosition, Quaternion.identity);
                break;
            case "Flamethrower":
                currentTurret = Instantiate(ftPreview, PlayerController.TurretSpawnPosition, Quaternion.identity);
                break;
            case "Ionic":
                currentTurret = Instantiate(ionicPreview, PlayerController.TurretSpawnPosition, Quaternion.identity);
                break;
        }
    }
}
