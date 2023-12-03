using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealthSound : MonoBehaviour
{
    public AudioSource healthSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healthSound.Play();
            Invoke("DestroyThis", 0.6f);
        }
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
