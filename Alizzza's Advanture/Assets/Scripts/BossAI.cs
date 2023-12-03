using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour
{
    [SerializeField] GameObject _tvExplosionPrefab;
    [SerializeField] GameObject _noisePrefab;

    public float JumpSpeed = 340;
    public int _startJumpingAt = 60;
    public int JumpDelay = 1;
    public int Health = 100;
    public Slider BossHealth;
    public GameObject BossBullet;

    private float _delayBeforeFiring = 3f;
    private Rigidbody2D _bossRigidbody;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _bulletSpawnPos;
    private bool _canFire, _isJumping;
    private Animator _tvAnimator;
    private AudioPlayer _audioPlayer;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        _bossRigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _tvAnimator = GetComponent<Animator>();

        _canFire = false;

        _bulletSpawnPos = gameObject.transform.Find("BulletSpawn").transform.position;
        Invoke("Reload", Random.Range(1f, _delayBeforeFiring));
    }

    void Update()
    {
       if(_canFire)
        {
            FireBullets();
            _canFire = false;

            if(Health < _startJumpingAt && _isJumping == false)
            {
                _tvAnimator.SetTrigger("attack");
                _delayBeforeFiring = 1.5f;
                InvokeRepeating("Jump", 0, JumpDelay);
                _isJumping = true;
            }
        }
    }

    void Reload()
    {
        _canFire = true;
    }

    void Jump()
    {
        _bossRigidbody.AddForce(new Vector2(0, JumpSpeed));
    }

    void FireBullets()
    {
        Instantiate(BossBullet, _bulletSpawnPos, Quaternion.identity);
        Invoke("Reload", _delayBeforeFiring);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            if (Health == 0)
            {
                FindObjectOfType<GameManager>().AddLive(1);
                _audioPlayer.PlayBossBoom();
                _tvAnimator.SetTrigger("death");
                Invoke("DestroyBossCollider", .5f);
                Invoke("BossDeath", 1f);
                
                Instantiate(_noisePrefab, transform.position, transform.rotation);
            }
            if(Health > 0)
            {
                Health--;
                BossHealth.value = (float)Health;
                _spriteRenderer.color = Color.red;
                Invoke("RestoreColor", 0.1f);
            }
        }
    }

    void RestoreColor()
    {
        _spriteRenderer.color = Color.white;
    }

    void DestroyBossCollider()
    {
        Destroy(gameObject.GetComponent<Collider2D>());
    }

    void BossDeath()
    {
        Instantiate(_tvExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);   
    }
}
