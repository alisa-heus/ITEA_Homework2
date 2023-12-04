using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _healthPoints = 1; 
    [SerializeField] GameObject _pickupParticles;

    private bool _wasCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddLive(_healthPoints);
        if (collision.tag == "Player" && !_wasCollected)
        {
            Instantiate(_pickupParticles, transform.position, transform.rotation);
            _wasCollected = true;
            Destroy(gameObject);
        }
    }
}
