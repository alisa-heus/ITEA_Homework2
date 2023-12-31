using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] Vector3 _platformVelocity;
    private bool _moving;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.tag != "Ground")
        {
            _moving = true;
            collision.transform.SetParent(transform);
        }
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            collision.collider.transform.SetParent(null);  
        }
    }

    private void FixedUpdate()
    {
        if(_moving)
        {
            transform.position += (_platformVelocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
