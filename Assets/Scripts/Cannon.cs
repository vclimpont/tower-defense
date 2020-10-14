using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public int boostDamageOnUpgrade;
    public float boostDetectRadiusOnUpgrade;
    public float boostDetectAngleOnUpgrade;

    private FieldOfView fov;
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
        st.AttackVisibleEnemy(fov.GetClosestEnemyTransform(fov.DetectEnemies()));
    }

    public void UpgradeTurret()
    {
        turret.UpgradeTurret();
        st.damages += boostDamageOnUpgrade;
        fov.SetFov(fov.detectRadius + boostDetectRadiusOnUpgrade, fov.detectAngle + boostDetectAngleOnUpgrade, transform.forward);
    }
}
