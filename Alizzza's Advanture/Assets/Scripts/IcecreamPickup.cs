using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecreamPickup : MonoBehaviour
{
    [SerializeField] int icecreamPoints = 5;
    AudioPlayer audioPlayer;
    [SerializeField] GameObject pickupParticles;

    bool wasCollected = false;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddScore(icecreamPoints);
        if (collision.tag == "Player" && !wasCollected)
        {
            Instantiate(pickupParticles, transform.position, transform.rotation);
            wasCollected = true;
            Destroy(gameObject);
            audioPlayer.PlayCandy();
        }
    }
}
