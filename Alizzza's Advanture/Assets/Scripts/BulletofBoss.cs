using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletofBoss : MonoBehaviour
{
    public Vector2 velocity;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
    }
}
