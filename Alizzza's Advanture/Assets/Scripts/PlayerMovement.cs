using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    [SerializeField] float _jumpForce = 5f;
    [SerializeField] float _climbSpeed = 5f;
    [SerializeField] Vector2 _deathKick = new Vector2(10f, 10f);
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _gun;

    private Vector2 moveInput;
    private Rigidbody2D _rigidBody;
    private Animator myAnimator;
    private AudioPlayer _audioPlayer;
    private CapsuleCollider2D _myBodyCollider;
    private float _gravityScaleAtStart;
    private bool _hasStarted = false;
    private bool _isAlive = true;
    
    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        _myBodyCollider = GetComponent<CapsuleCollider2D>();
        _gravityScaleAtStart = _rigidBody.gravityScale;
    }

    private void Update()
    {
        if (_isAlive == false) { return;}
        CharacterState();
        ClimbLadder();
        FlipSprite();
        Die(); 
    }

    private void OnQuit(InputValue value)
    {
        Application.Quit();
    }
    private void OnMove(InputValue value)
    {
        if (_isAlive == false) { return; }
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (_isAlive == false) { return; }

        if (_myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) == false)
        {
            return;
        } 

        if (value.isPressed)
        {
            _rigidBody.velocity += new Vector2(0f, _jumpForce);
            myAnimator.SetBool("isJumping", true);
        }
    }

    private void OnFire(InputValue value)
    {
        if (_isAlive == false) { return;}
        Instantiate(_bullet, _gun.position, transform.rotation);
    }

    private void CharacterState()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * _speed, _rigidBody.velocity.y);
        _rigidBody.velocity = playerVelocity;

        //Plays walking animation when character is moving on x-axis
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);

        if(_myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) == true && _hasStarted == false)
        {
            _hasStarted = true;
        }

        if (_hasStarted == false) return;

        //Plays jumping animation when not walking and not climbing
        if (_myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) == false && _myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")) == false)
        {
          myAnimator.SetBool("isJumping", true);
        } 
        else
        {
          myAnimator.SetBool("isJumping", false);
        }
    }
  
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon; 
        if(playerHasHorizontalSpeed == true)
        {
            //Flips character horizontally depending on her direction on x axis.
            transform.localScale = new Vector2(Mathf.Sign(_rigidBody.velocity.x), 1f);
        }   
    }

    private void ClimbLadder()
    {
        if (_myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")) == false)
        {
            _rigidBody.gravityScale = _gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        //Turns off gravity and make character move on y-axis
        Vector2 climbVelocity = new Vector2(_rigidBody.velocity.x, moveInput.y * _climbSpeed);
        _rigidBody.velocity = climbVelocity;
        _rigidBody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(_rigidBody.velocity.y) > Mathf.Epsilon;
        
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
    }

    private void Die()
    {
        if(_myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            _isAlive = false;
            myAnimator.SetTrigger("Dying");
            _audioPlayer.PlayDeath(); 
            _rigidBody.velocity = _deathKick;
            Invoke("DeathLevelReload", 0.7f);   
        }
    }
    private void DeathLevelReload()
    {
        FindObjectOfType<GameManager>().ProcessPlayerDeath();
    }
}
