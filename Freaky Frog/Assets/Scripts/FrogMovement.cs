using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrogMovement : MonoBehaviour
{ 
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _minHoldTime = .5f;
    [SerializeField] private float _maxHoldTime = 2f;

    private float _holdTime;
    private bool _isGrounded;

    public float JumpForce = 2f;
    public LayerMask GroundLayer;
    public float CircleRadius = .7f;
    void Start()
    {

    }

    private void Update()
    {
        _isGrounded = IsGrounded();

        if (Input.GetMouseButtonDown(0) && _isGrounded == true)
        {
            _holdTime = 0f;
        }

        if (Input.GetMouseButton(0) && _isGrounded == true)
        {
            _holdTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0) && _isGrounded == true)  
        {
            Jump();  
        }
    }

    private void Jump()
    {
        if (_isGrounded == true) 
        {
            float calculatedJumpForce = Mathf.Clamp(_holdTime, _minHoldTime, _maxHoldTime) * JumpForce;
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, calculatedJumpForce);
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
