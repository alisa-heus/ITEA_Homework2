using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] int cakePoints = 50;
    AudioPlayer audioPlayer;
    [SerializeField] GameObject cakeParticles;

    bool wasCollected = false;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddScore(cakePoints);
        if (collision.tag == "Player" && !wasCollected)
        {
            Instantiate(cakeParticles, transform.position, transform.rotation);
            wasCollected = true;
            Destroy(gameObject);
            
            audioPlayer.PlayClap();
        }
    }
}
