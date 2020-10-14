using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int goldsOnStart;
    public GameObject cannonPrefab;
    public GameObject ftPrefab;
    public GameObject ionicPrefab;

    private UISpawnTurret UIst;
    private GameObject currentTurret;
    private GameObject currentTurretPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Golds = goldsOnStart;
        PlayerController.Buying = false;

        UIst = GetComponent<UISpawnTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PlayerController.Buying)
            {
                UIst.CancelSpawn();
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            SpawnTurret();
        }

        if(Input.GetMouseButtonDown(1))
        {
            RotateTurret();
        }
    }

    void LateUpdate()
    {
        PlayerController.OnTile = false;
    }

    void SpawnTurret()
    {
        if (PlayerController.Buying && PlayerController.OnTile && !PlayerController.CurrentTile.HasTurret)
        {
            Vector3 spawnPosition = PlayerController.TurretSpawnPosition + new Vector3(0, currentTurretPrefab.transform.localScale.y, 0);
            currentTurret = Instantiate(currentTurretPrefab, spawnPosition, Quaternion.Euler(PlayerController.TurretSpawnRotation));
            PlayerController.CurrentTile.HasTurret = true;
        }
    }

    void RotateTurret()
    {
        if (PlayerController.Buying && PlayerController.OnTile)
        {
            PlayerController.TurretSpawnRotation += new Vector3(0, 45, 0);
        }
    }

    public void SetCurrentTurretPrefab(string turretType)
    {
        switch (turretType)
        {
            case "Cannon":
                currentTurretPrefab = cannonPrefab;
                break;
            case "Flamethrower":
                currentTurretPrefab = ftPrefab;
                break;
            case "Ionic":
                currentTurretPrefab = ionicPrefab;
                break;
        }
    }

}
