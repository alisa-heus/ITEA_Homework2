using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerExitSound : MonoBehaviour
{
    [FormerlySerializedAs("playExitSound")]
    [SerializeField] AudioSource _playExitSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playExitSound.Play();
        }
    }
}