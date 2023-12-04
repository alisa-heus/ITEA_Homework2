using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletofBoss : MonoBehaviour
{
    [SerializeField] Vector2 _velocity;
    private Rigidbody2D _bulettRigidBody;
    
    void Start()
    {
        _bulettRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _bulettRigidBody.velocity = _velocity;
    }
}
