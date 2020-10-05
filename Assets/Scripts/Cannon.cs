using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float detectAngle;
    public float detectRadius;
    public float damages;
    public float hitRate;

    private FieldOfView fov;
    private Turret turret;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponent<Turret>();
        fov = new FieldOfView(transform, detectRadius, detectAngle);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        AttackVisibleEnemies();
    }

    void AttackVisibleEnemies()
    {
        if(canShoot)
        {
            Transform closestEnemy = fov.GetClosestEnemyTransform(fov.DetectEnemies());
            if(closestEnemy != null)
            {
                StartCoroutine(Shoot(closestEnemy.GetComponent<Enemy>()));
            }
        }
    }

    IEnumerator Shoot(Enemy enemy)
    {
        canShoot = false;
        Debug.Log("PAF");
        enemy.Damage(damages);

        yield return new WaitForSeconds(hitRate);
        canShoot = true;
    }

    void OnDrawGizmos()
    {
        Vector3 minusAngleDir = Quaternion.Euler(0, -detectAngle / 2, 0) * transform.forward;
        Vector3 plusAngleDir = Quaternion.Euler(0, detectAngle / 2, 0) * transform.forward;
        Vector3 minusAnglePos = transform.position + minusAngleDir * detectRadius;
        Vector3 plusAnglePos = transform.position + plusAngleDir * detectRadius;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, minusAnglePos);
        Gizmos.DrawLine(transform.position, plusAnglePos);
    }
}
