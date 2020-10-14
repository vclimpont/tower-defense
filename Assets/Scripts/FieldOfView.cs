using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float detectRadius;
    public float detectAngle;

    public Vector3 FovDirection { get; set; }

    void Start()
    {
        if(FovDirection == Vector3.zero)
        {
            FovDirection = transform.forward;
        }
    }

    public List<Transform> DetectEnemies()
    {
        List<Transform> enemiesInRange = new List<Transform>();
        Collider[] enemiesInViewRadius = Physics.OverlapSphere(transform.position, detectRadius, LayerMask.GetMask("Enemy"));

        for (int i = 0; i < enemiesInViewRadius.Length; i++)
        {
            Transform enemy = enemiesInViewRadius[i].transform;
            Vector3 dirToEnemy = (enemy.position - transform.position).normalized;

            if (Vector3.Angle(FovDirection, dirToEnemy) < detectAngle / 2)
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

    public void SetFov(float _detectRadius, float _detectAngle, Vector3 _fovDirection)
    {
        detectRadius = _detectRadius;
        detectAngle = _detectAngle;
        FovDirection = _fovDirection;
    }

    void OnDrawGizmos()
    {
        Vector3 minusAngleDir = Quaternion.Euler(0, -detectAngle / 2, 0) * FovDirection;
        Vector3 plusAngleDir = Quaternion.Euler(0, detectAngle / 2, 0) * FovDirection;
        Vector3 minusAnglePos = transform.position + minusAngleDir * detectRadius;
        Vector3 plusAnglePos = transform.position + plusAngleDir * detectRadius;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, minusAnglePos);
        Gizmos.DrawLine(transform.position, plusAnglePos);
    }
}
