using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] GameObject _tvExplosionPrefab;
    [SerializeField] Collider2D _enemyCollider;
    [SerializeField] Collider2D _enemyStopperCollider;

    private Rigidbody2D _enemyRigidbody;
    private Animator _tvAnimator;
    private AudioPlayer _audioPlayer;
    
    
    private void Awake()
    {     
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        _tvAnimator = GetComponent<Animator>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _enemyRigidbody.velocity = new Vector2(_moveSpeed, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Makes enemy move in other direction when colliding with objects
        _moveSpeed = -_moveSpeed;
        FlipEnemyFacing();
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(_enemyRigidbody.velocity.x)), 1f);
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
