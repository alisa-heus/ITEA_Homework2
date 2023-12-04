using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;
    private Rigidbody2D _bulletRigidbody;
    private PlayerMovement _player;
    private float _xSpeed;
    
    private void Start()
    {
        _bulletRigidbody = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<PlayerMovement>();
        _xSpeed = _player.transform.localScale.x * _bulletSpeed;  
    }
    private void Update()
    {
        //Flips the bullet left or right depending on player's condition 
        if (_player.transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(_bulletRigidbody.velocity.x), 1f);
        }
        //Makes the bullet move on x axis + destroys it
        _bulletRigidbody.velocity = new Vector2(_xSpeed, 0f);
        Invoke("DestroyIt", 1.7f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyIt();
    }

    void DestroyIt()
    {
        Destroy(gameObject);
    }
}
