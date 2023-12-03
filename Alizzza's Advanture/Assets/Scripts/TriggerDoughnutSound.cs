using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoughnutSound : MonoBehaviour
{
    public AudioSource dougnutSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           dougnutSound.Play();
           Invoke("DestroyThis", 0.7f);
        }
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
