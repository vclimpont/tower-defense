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

    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    void InitializeDestinations()
    {
        destTransforms = new List<Transform>();

        foreach(Transform child in transform)
        {
            destTransforms.Add(child);
        }
    }

    void Move()
    {

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
}
