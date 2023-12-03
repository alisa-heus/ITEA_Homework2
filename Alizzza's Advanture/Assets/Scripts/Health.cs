using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthPoints = 1;
    
    [SerializeField] GameObject pickupParticles;

    bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddLive(healthPoints);
        if (collision.tag == "Player" && !wasCollected)
        {
            Instantiate(pickupParticles, transform.position, transform.rotation);
            wasCollected = true;
            Destroy(gameObject);
        }
    }
}
