using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private Vector3 target;

    public void Initialize(Vector3 _target)
    {
        speed = 0.5f;
        target = _target;
    }

    void Update()
    {
        if(transform.position == target)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
}
