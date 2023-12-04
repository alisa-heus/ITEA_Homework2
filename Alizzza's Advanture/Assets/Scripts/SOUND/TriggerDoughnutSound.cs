using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerDoughnutSound : MonoBehaviour
{
    [FormerlySerializedAs("dougnutSound")]
    [SerializeField] AudioSource _dougnutSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           _dougnutSound.Play();
            StartCoroutine(DestroyThis());
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}
