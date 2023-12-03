using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitSound : MonoBehaviour
{
    public AudioSource playExitSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playExitSound.Play();
        }
    }
}