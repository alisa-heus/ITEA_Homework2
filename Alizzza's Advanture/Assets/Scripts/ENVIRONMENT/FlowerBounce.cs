using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBounce : MonoBehaviour
{
    private AudioPlayer _audioPlayer;
    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _audioPlayer.PlayBounce();
        }
    }
}
