using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ionic : MonoBehaviour
{
    public float slowPercentage;
    public float slowRate;

    private FieldOfView fov;
    private Turret turret;
    private bool canSlow;

    // Start is called before the first frame update
    void Start()
    {
        fov = GetComponent<FieldOfView>();
        turret = GetComponent<Turret>();
        canSlow = true;
    }

    // Update is called once per frame
    void Update()
    {
        SlowVisibleEnemies(fov.DetectEnemies());
    }

    void SlowVisibleEnemies(List<Transform> enemiesTransform)
    {
        if (canSlow)
        {
            List<Enemy> enemies = new List<Enemy>();
            foreach (Transform enemy in enemiesTransform)
            {
                enemies.Add(enemy.GetComponent<Enemy>());
            }

            StartCoroutine(Slow(enemies));
        }
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
        foreach (Enemy enemy in enemies)
        {
            enemy.speed = enemy.GetMaxSpeed();
        }
    }
}
