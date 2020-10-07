using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
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
        st.AttackVisibleEnemies(fov.DetectEnemies());
    }
}
