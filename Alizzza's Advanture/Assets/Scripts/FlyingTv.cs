using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTv : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.5f;
    Rigidbody2D myRigidbody;
    Animator tvAnimator;
    AudioPlayer audioPlayer;
    [SerializeField] GameObject tvExplosionPrefab;
    Transform explosionSpawner;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        tvAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(0, moveSpeed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Stoper")
        {
            moveSpeed = -moveSpeed;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            audioPlayer.PlayTvBoom();
            tvAnimator.SetTrigger("death");
            moveSpeed = 0;
            Invoke("TvDeath", 0.6f);
            Instantiate(tvExplosionPrefab, transform.position, transform.rotation);

        }
    }
    void TvDeath()
    {
        Destroy(gameObject);
    }
}
