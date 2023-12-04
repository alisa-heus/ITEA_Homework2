using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecreamPickup : MonoBehaviour
{
    [SerializeField] int _icecreamPoints = 5;  
    [SerializeField] GameObject _pickupParticles;

    private AudioPlayer _audioPlayer;
    private bool _wasCollected = false;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddScore(_icecreamPoints);
        if (collision.tag == "Player" && !_wasCollected)
        {
            Instantiate(_pickupParticles, transform.position, transform.rotation);
            _wasCollected = true;
            Destroy(gameObject);
            _audioPlayer.PlayCandy();
        }
    }
}
