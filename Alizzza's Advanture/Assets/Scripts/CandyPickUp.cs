using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPickUp : MonoBehaviour
{
    [SerializeField] int _candyPoints = 1;
    [SerializeField] GameObject _pickupParticles;

    private AudioPlayer _audioPlayer;
    private bool _wasCollected = false;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddScore(_candyPoints);

        if (collision.tag == "Player" && !_wasCollected)
        {
            Instantiate(_pickupParticles, transform.position, transform.rotation);
            _wasCollected = true;
            Destroy(gameObject);
            _audioPlayer.PlayCandy();
        }
    }
}
