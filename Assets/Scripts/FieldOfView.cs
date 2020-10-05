using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView
{
    private Transform transform;
    private float detectRadius;
    private float detectAngle;

    public FieldOfView(Transform transform, float detectRadius, float detectAngle)
    {
        this.transform = transform;
        this.detectAngle = detectAngle;
        this.detectRadius = detectRadius;
    }

    public List<Transform> DetectEnemies()
    {
        List<Transform> enemiesInRange = new List<Transform>();
        Collider[] enemiesInViewRadius = Physics.OverlapSphere(transform.position, detectRadius, LayerMask.GetMask("Enemy"));

        for (int i = 0; i < enemiesInViewRadius.Length; i++)
        {
            Transform enemy = enemiesInViewRadius[i].transform;
            Vector3 dirToEnemy = (enemy.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToEnemy) < detectAngle / 2)
            {
                enemiesInRange.Add(enemy);
            }
        }

        return enemiesInRange;
    }

    public Transform GetClosestEnemyTransform(List<Transform> enemiesInRange)
    {
        float closestEnemyDst = Mathf.Infinity;
        Transform closestEnemyTransform = null;

        foreach (Transform tEnemy in enemiesInRange)
        {
            float dstToEnemy = Vector3.Distance(transform.position, tEnemy.position);
            if(dstToEnemy < closestEnemyDst)
            {
                closestEnemyDst = dstToEnemy;
                closestEnemyTransform = tEnemy;
            }
        }

        return closestEnemyTransform;
    }

}
