using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerBounce : MonoBehaviour
{
    AudioPlayer audioPlayer;
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioPlayer.PlayBounce();
        }
    }
}
