using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ionic : MonoBehaviour
{
    public float slowPercentage;
    public float slowRate;
    public float timeBtwFreeze;
    public float freezeDuration;

    private FieldOfView fov;
    private Turret turret;
    private float crtFreezeCD;
    private bool canSlow;
    private bool canFreeze;
    private bool isFreezing;

    // Start is called before the first frame update
    void Start()
    {
        fov = GetComponent<FieldOfView>();
        turret = GetComponent<Turret>();
        canSlow = true;
        canFreeze = true;
        isFreezing = false;
        crtFreezeCD = 0;
        UpgradeTurret();
    }

    // Update is called once per frame
    void Update()
    {
        List<Transform> visibleEnemies = fov.DetectEnemies();

        if (turret.Upgraded)
        {
            FreezeVisibleEnemies(visibleEnemies);
        }

        if (!isFreezing)
        {
            SlowVisibleEnemies(visibleEnemies);
        }
    }

    void SlowVisibleEnemies(List<Transform> enemiesTransform)
    {
        if (canSlow && enemiesTransform.Count > 0)
        {
            List<Enemy> enemies = new List<Enemy>();
            foreach (Transform enemy in enemiesTransform)
            {
                enemies.Add(enemy.GetComponent<Enemy>());
            }

            StartCoroutine(Slow(enemies));
        }
    }

    void FreezeVisibleEnemies(List<Transform> enemiesTransform)
    {
        if (canFreeze)
        {
            if(enemiesTransform.Count > 0)
            {
                List<Enemy> enemies = new List<Enemy>();
                foreach (Transform enemy in enemiesTransform)
                {
                    enemies.Add(enemy.GetComponent<Enemy>());
                }

                StartCoroutine(Freeze(enemies));
            }
        }
        else
        {
            UpdateFreezeCooldown();
        }
    }

    void UpdateFreezeCooldown()
    {
        if(crtFreezeCD <= timeBtwFreeze)
        {
            crtFreezeCD += Time.deltaTime;
        }
        else
        {
            crtFreezeCD = 0;
            canFreeze = true;
        }
    }

    public void UpgradeTurret()
    {
        turret.UpgradeTurret();
    }

    IEnumerator Slow(List<Enemy> enemies)
    {
        canSlow = false;

        foreach(Enemy enemy in enemies)
        {
            enemy.speed = enemy.GetMaxSpeed() * (1f - slowPercentage);
        }

        yield return new WaitForSeconds(slowRate);

        canSlow = true;
        if(!isFreezing)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.speed = enemy.GetMaxSpeed();
            }
        }
    }

    IEnumerator Freeze(List<Enemy> enemies)
    {
        canFreeze = false;
        isFreezing = true;
        Debug.Log("FREEZE");
        foreach (Enemy enemy in enemies)
        {
            enemy.speed = 0f;
        }

        yield return new WaitForSeconds(freezeDuration);

        isFreezing = false;
        if(canSlow)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.speed = enemy.GetMaxSpeed();
            }
        }
    }
}
