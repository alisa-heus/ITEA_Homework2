using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wowTrigger : MonoBehaviour
{
    public AudioSource wowSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {   
            wowSound.Play();
            Invoke("DestroyThis", 1.8f);
        }
    }
    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
