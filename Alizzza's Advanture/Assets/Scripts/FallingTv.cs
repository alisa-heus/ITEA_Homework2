using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTv : MonoBehaviour
{
    
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" )
        {
            audioPlayer.PlayTvBoom();
            tvAnimator.SetTrigger("death");
            Invoke("TvDeath", 0.35f);
            Instantiate(tvExplosionPrefab, transform.position, transform.rotation);
        }
    }
    void TvDeath()
    {
        Destroy(gameObject);
    }
}
