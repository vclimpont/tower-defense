using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IKillable
{
    public GameObject destinations;
    public int health;
    public int goldGiven;
    public float speed;

    private List<Transform> destTransforms;
    private float maxSpeed;
    private int currentWaypoint;
    private bool initialized;

    public void Initialize(GameObject destinations)
    {
        destTransforms = new List<Transform>();
        maxSpeed = speed;
        currentWaypoint = 0;
        InitializeDestinations(destinations);
        initialized = true;
    }

    void FixedUpdate()
    {
        if(initialized)
        {
            Move();
        }
    }

    void InitializeDestinations(GameObject destinations)
    {
        if(destinations != null)
        {
            foreach (Transform child in destinations.transform)
            {
                destTransforms.Add(child);
            }
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
        else
        {
            DamagePlayer();
            Kill();
        }
    }

    public void Damage(int damageTaken)
    {
        health -= damageTaken;

        if(health <= 0)
        {
            GiveGolds();
            Kill();
        }
    }

    void DamagePlayer()
    {
        PlayerController.Health--;
    }

    void GiveGolds()
    {
        PlayerController.Gold += goldGiven;
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
