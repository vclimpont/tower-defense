using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawnTurret : MonoBehaviour
{
    public GameObject cannonPreview;
    public GameObject ftPreview;
    public GameObject ionicPreview;

    private GameManager gm;
    private GameObject currentTurretPreview;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        gm = GetComponent<GameManager>();
    }

    void Update()
    {
        if(PlayerController.Buying)
        {
            if(!PlayerController.OnTile)
            {
                PlayerController.TurretSpawnPosition = GetMousePositionInWorld();
            }

            currentTurretPreview.transform.position = PlayerController.TurretSpawnPosition;
        }
    }

    Vector3 GetMousePositionInWorld()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 15));
        return mousePosition;
    }

    public void CancelSpawn()
    {
        PlayerController.Buying = false;
        Destroy(currentTurretPreview);
    }

    public void SpawnTurret(string turretType)
    {
        if(!PlayerController.Buying)
        {
            PlayerController.Buying = true;
            PlayerController.TurretSpawnPosition = GetMousePositionInWorld();
            gm.SetCurrentTurret(turretType);
            switch (turretType)
            {
                case "Cannon":
                    currentTurretPreview = Instantiate(cannonPreview, PlayerController.TurretSpawnPosition, Quaternion.identity);
                    break;
                case "Flamethrower":
                    currentTurretPreview = Instantiate(ftPreview, PlayerController.TurretSpawnPosition, Quaternion.identity);
                    break;
                case "Ionic":
                    currentTurretPreview = Instantiate(ionicPreview, PlayerController.TurretSpawnPosition, Quaternion.identity);
                    break;
            }
        }
    }
}
