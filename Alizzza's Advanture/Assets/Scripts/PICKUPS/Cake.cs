using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cake : MonoBehaviour
{
    [SerializeField] int _cakePoints = 50;
    [FormerlySerializedAs("cakeParticles")]
    [SerializeField] GameObject _cakeParticles;

    private AudioPlayer _audioPlayer;
    private bool _wasCollected = false;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddScore(_cakePoints);

        if (collision.tag == "Player" && _wasCollected == false)
        {
            Instantiate(_cakeParticles, transform.position, transform.rotation);
            _wasCollected = true;
            Destroy(gameObject);  
            _audioPlayer.PlayClap();
        }
    }
}
