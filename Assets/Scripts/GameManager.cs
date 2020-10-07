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
    }

    void LateUpdate()
    {
        PlayerController.OnTile = false;
    }

    void SpawnTurret()
    {
        if (PlayerController.Buying && PlayerController.OnTile)
        {
            Vector3 spawnPosition = PlayerController.TurretSpawnPosition + new Vector3(0, currentTurret.transform.localScale.y, 0);
            currentTurret = Instantiate(currentTurret, spawnPosition, Quaternion.identity);
        }
    }

    public void SetCurrentTurret(string turretType)
    {
        switch (turretType)
        {
            case "Cannon":
                currentTurret = cannonPrefab;
                break;
            case "Flamethrower":
                currentTurret = ftPrefab;
                break;
            case "Ionic":
                currentTurret = ionicPrefab;
                break;
        }
    }

}
