using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _force = 5f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioClip _loseClip;
    [SerializeField] private GameManager _gameManager;

    public int Score = 0;
    
    private Rigidbody _playerRigidBody;
    
   
    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Multiplying to Time.fixedDeltaTime didn't give the desired effect
        if(Input.GetKey(KeyCode.W))
        {
            _playerRigidBody.velocity = new Vector3(0, 0, _force);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if(Input.GetKey(KeyCode.S)) 
        {
            _playerRigidBody.velocity = new Vector3(0, 0, -_force);
            transform.localEulerAngles = new Vector3(0, -180, 0);
        }

        if(Input.GetKey(KeyCode.A)) 
        {
            _playerRigidBody.velocity = new Vector3(-_force, 0, 0);
            transform.localEulerAngles = new Vector3(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            _playerRigidBody.velocity = new Vector3(_force, 0, 0);
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Renderer>(out Renderer renderer) == true && _gameManager.TimerOn == true)
        {
            if(renderer.material.color == this.transform.Find("Body").GetComponent<Renderer>().material.color)
            {
                Score++;
                _gameManager.ChangeColor();
                Debug.Log("Score: " + Score);
                _audioSource.PlayOneShot(_winClip);
            }
            else
            {
                if (collision.gameObject.name != "floor")
                {
                    Score--;
                    if (Score < 0)
                    {
                        Score = 0;
                    }
                    Debug.Log("Wrong wall! Score: " + Score);
                    _audioSource.PlayOneShot(_loseClip);
                }
            }
        }
        
    }
}
