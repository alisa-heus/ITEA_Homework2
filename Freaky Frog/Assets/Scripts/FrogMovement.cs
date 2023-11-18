using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrogMovement : MonoBehaviour
{

    public float jumpForce = 10f; 
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))  // Check for mouse release (left mouse button)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Check if the character is on the ground or a platform before jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
