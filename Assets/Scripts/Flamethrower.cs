using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public GameObject upgradeCannonGO;
    public int boostDamageOnUpgrade;

    private FieldOfView fov;
    private FieldOfView upgradedFov;
    private Turret turret;
    private ShootableTurret st;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponent<Turret>();
        fov = GetComponent<FieldOfView>();
        st = GetComponent<ShootableTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        st.AttackVisibleEnemies(fov.DetectEnemies());

        if (turret.Upgraded)
        {
            st.AttackVisibleEnemies(upgradedFov.DetectEnemies());
        }
    }

    public void UpgradeTurret()
    {
        turret.UpgradeTurret();
        st.damages += boostDamageOnUpgrade;
        BuildCannonOnUpgrade();
        AddFovOnUpgrade();
    }

    void BuildCannonOnUpgrade()
    {
        GameObject upgradedCannon = Instantiate(upgradeCannonGO, transform);
        upgradedCannon.transform.localPosition = new Vector3(0, 0.22f, -0.68f);
        upgradedCannon.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        upgradedCannon.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    void AddFovOnUpgrade()
    {
        upgradedFov = gameObject.AddComponent<FieldOfView>();
        upgradedFov.SetFov(fov.detectRadius, fov.detectAngle, -transform.forward);
    }
}
