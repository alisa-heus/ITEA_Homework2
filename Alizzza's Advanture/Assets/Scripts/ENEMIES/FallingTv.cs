using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTv : MonoBehaviour
{
    [SerializeField] GameObject _tvExplosionPrefab;
    private Animator _tvAnimator;
    private AudioPlayer _audioPlayer; 

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        _tvAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" )
        {
            _audioPlayer.PlayTvBoom();
            _tvAnimator.SetTrigger("death");
            StartCoroutine(TvDeath());
            Instantiate(_tvExplosionPrefab, transform.position, transform.rotation);
        }
    }

    IEnumerator TvDeath()
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);
    }
}
