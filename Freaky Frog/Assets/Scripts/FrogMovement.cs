using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrogMovement : MonoBehaviour
{ 
    [SerializeField] private Rigidbody2D _rigidBody;
    private bool _isGrounded;
    public float JumpForce = 10f;
    public LayerMask GroundLayer;
    public float CircleRadius = .7f;
    void Start()
    {

    }

    private void Update()
    {
        _isGrounded = IsGrounded();

        if (Input.GetMouseButtonUp(0) && _isGrounded == true)  
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (_isGrounded == true) 
        {
            Debug.Log("Jumping");
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, JumpForce);
        }    
    }

    private bool IsGrounded()
    {
        // Check if there is a collider below the object
        Collider2D collider = Physics2D.OverlapCircle(transform.position, CircleRadius, GroundLayer);
        // If the collider is not null, then the object is grounded
        return collider != null;
    }
}
