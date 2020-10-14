using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int goldsOnStart;
    public int healthOnStart;
    public GameObject cannonPrefab;
    public GameObject ftPrefab;
    public GameObject ionicPrefab;

    private UISpawnTurret UIst;
    private GameObject currentTurret;
    private GameObject currentTurretPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Gold = goldsOnStart;
        PlayerController.Health = healthOnStart;
        PlayerController.Buying = false;

        UIst = GetComponent<UISpawnTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

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
            UpgradeTurret();
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

    void UpgradeTurret()
    {
        if (!PlayerController.Buying && PlayerController.OnTile && PlayerController.CurrentTile.HasTurret)
        {
            Turret turretToUpgrade = PlayerController.CurrentTile.TurretOnTile;
            if(PlayerController.Gold >= turretToUpgrade.costUpgrade && !turretToUpgrade.Upgraded)
            {
                PlayerController.Gold -= turretToUpgrade.costUpgrade;
                UpgradeTurret(turretToUpgrade);
            }
        }
    }

    void SpawnTurret()
    {
        if (PlayerController.Buying && PlayerController.OnTile && !PlayerController.CurrentTile.HasTurret)
        {
            int cost = currentTurretPrefab.GetComponent<Turret>().costBuy;
            if (PlayerController.Gold >= cost)
            {
                PlayerController.Gold -= cost;
                Vector3 spawnPosition = PlayerController.TurretSpawnPosition + new Vector3(0, currentTurretPrefab.transform.localScale.y, 0);
                currentTurret = Instantiate(currentTurretPrefab, spawnPosition, Quaternion.Euler(PlayerController.TurretSpawnRotation));
                PlayerController.CurrentTile.HasTurret = true;
                PlayerController.CurrentTile.TurretOnTile = currentTurret.GetComponent<Turret>();
            }
        }
    }

    void RotateTurret()
    {
        if (PlayerController.Buying && PlayerController.OnTile)
        {
            PlayerController.TurretSpawnRotation += new Vector3(0, 45, 0);
        }
    }

    void UpgradeTurret(Turret turretToUpgrade)
    {
        GameObject turretGO = turretToUpgrade.gameObject;
        Cannon cannon = turretGO.GetComponent<Cannon>();
        Flamethrower ft = turretGO.GetComponent<Flamethrower>();
        Ionic ionic = turretGO.GetComponent<Ionic>();

        if(cannon != null)
        {
            cannon.UpgradeTurret();
        }
        else if(ft != null)
        {
            ft.UpgradeTurret();
        }
        else if(ionic != null)
        {
            ionic.UpgradeTurret();
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
