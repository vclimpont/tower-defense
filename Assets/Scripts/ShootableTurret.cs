﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableTurret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int damages;
    public float hitRate;

    public bool CanShoot { get; set; }

    void Start()
    {
        CanShoot = true;
    }

    public void AttackVisibleEnemy(Transform enemy)
    {
        if (CanShoot)
        {
            if (enemy != null)
            {
                StartCoroutine(Shoot(enemy.GetComponent<Enemy>()));
            }
        }
    }

    public void AttackVisibleEnemies(List<Transform> enemiesTransform)
    {
        if(CanShoot)
        {
            List<Enemy> enemies = new List<Enemy>();
            foreach (Transform enemy in enemiesTransform)
            {
                enemies.Add(enemy.GetComponent<Enemy>());
            }
            
            if(enemies.Count > 0)
            {
                StartCoroutine(Shoot(enemies));
            }
        }
    }

    IEnumerator Shoot(Enemy enemy)
    {
        CanShoot = false;
        GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletGO.GetComponent<Bullet>().Initialize(enemy.transform.position);
        enemy.Damage(damages);

        yield return new WaitForSeconds(hitRate);
        CanShoot = true;
    }

    IEnumerator Shoot(List<Enemy> enemies)
    {
        CanShoot = false;

        foreach(Enemy enemy in enemies)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletGO.GetComponent<Bullet>().Initialize(enemy.transform.position);
            enemy.Damage(damages);
        }

        yield return new WaitForSeconds(hitRate);
        CanShoot = true;
    }
}
