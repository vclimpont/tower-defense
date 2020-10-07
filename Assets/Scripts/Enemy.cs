using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IKillable
{
    public GameObject destinations;
    public float health;
    public float goldGiven;
    public float speed;

    private List<Transform> destTransforms;
    private float maxSpeed;
    private int currentWaypoint;

    void Start()
    {
        maxSpeed = speed;
        currentWaypoint = 0;
        InitializeDestinations();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InitializeDestinations()
    {
        destTransforms = new List<Transform>();

        foreach(Transform child in destinations.transform)
        {
            destTransforms.Add(child);
        }
    }

    void Move()
    {
        if(currentWaypoint < destTransforms.Count)
        {
            if(Vector3.Distance(transform.position, destTransforms[currentWaypoint].position) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destTransforms[currentWaypoint].position, speed);
            }
            else
            {
                currentWaypoint++;
            }
        }
    }

    public void Damage(float damageTaken)
    {
        health -= damageTaken;

        if(health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
}
