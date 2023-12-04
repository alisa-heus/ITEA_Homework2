using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTv : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1.5f;
    [SerializeField] GameObject _tvExplosionPrefab;
    [SerializeField] Collider2D _enemyCollider;
    [SerializeField] Collider2D _enemyStopperCollider;

    private Rigidbody2D _myRigidbody;
    private Animator _tvAnimator;
    private AudioPlayer _audioPlayer;
    
    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        _tvAnimator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _myRigidbody.velocity = new Vector2(0, _moveSpeed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Stoper")
        {
            _moveSpeed = -_moveSpeed;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(_enemyCollider);
            Destroy(_enemyStopperCollider);
            _audioPlayer.PlayTvBoom();
            _tvAnimator.SetTrigger("death");
            _moveSpeed = 0;
            StartCoroutine(TvDeath());
            Instantiate(_tvExplosionPrefab, transform.position, transform.rotation);
        }
    }
    IEnumerator TvDeath()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);
    }
}
