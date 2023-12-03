using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] int _doughnutPoints = 10;
    [SerializeField] GameObject _pickupParticles;

    private bool _wasCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddScore(_doughnutPoints);
        if(collision.tag == "Player" && !_wasCollected)
        {
            Instantiate(_pickupParticles, transform.position, transform.rotation);
            _wasCollected = true;
            Destroy(gameObject);  
        }
    }
}
