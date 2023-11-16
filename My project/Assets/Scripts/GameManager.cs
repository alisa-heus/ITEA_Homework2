using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameObject[] _walls;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private CharacterMovement _character;

    public bool TimerOn;

    private float _timeLeft = 50f;
    private float _changingColorsInterval = 2.2f;
    private float _resetGameTime = 3f;

    private void Start()
    {
        TimerOn = true;
        InvokeRepeating("ChangeColor", 0, _changingColorsInterval);
    }

    private void Update()
    {
        if(TimerOn)
        {
            if(_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
            }
            else
            {
                _timeLeft = 0;
                TimerOn = false;
                Debug.Log("Time is up! Your score is: " + _character.Score);
                _timerText.text = $"Score: {_character.Score}";
                Invoke("ResetGame", _resetGameTime);
            }
        }
    }
    public void ChangeColor()
    {
        if(TimerOn == false) { return; }
        foreach(var wall  in _walls) 
        {
            wall.GetComponent<Renderer>().material = _materials[Random.Range(0, _materials.Length)];
        }

        _character.transform.Find("Body").GetComponent<Renderer>().material = 
        _walls[Random.Range(0, _walls.Length)].GetComponent<Renderer>().material;
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
