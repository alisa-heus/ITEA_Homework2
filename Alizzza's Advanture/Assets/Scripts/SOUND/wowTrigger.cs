using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class wowTrigger : MonoBehaviour
{
    [FormerlySerializedAs("wowSound")]
    [SerializeField] AudioSource _wowSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.tag == "Player")
        {   
            _wowSound.Play();
            StartCoroutine(DestroySoundTrigger());
        }
    }

    IEnumerator DestroySoundTrigger()
    {
        yield return new WaitForSeconds(1.8f);
        Destroy(this.gameObject);
        Debug.Log("Sound trigger is destroyed");
    }
}
