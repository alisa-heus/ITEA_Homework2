using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerHealthSound : MonoBehaviour
{
    [FormerlySerializedAs("healthSound")]
    [SerializeField] AudioSource _healthSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _healthSound.Play();
            StartCoroutine(DestroyThis());
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);
    }
}
