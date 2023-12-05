using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _livesText;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] Lives _live;

    public GameObject TryAgain;
    public int PlayerLives = 3;
    public int Score = 0;

    private AudioPlayer _audioPlayer;

    private void Awake()
    {
        //Singletone, keeps the information from level1
        int numGameManagers = FindObjectsOfType<GameManager>().Length;

        if (numGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void Start()
    {
        _livesText.text = PlayerLives.ToString();
        _scoreText.text = Score.ToString();
        _live.ResetRound();
    }

    public void AddScore(int pointsToAdd)
    {
        Score += pointsToAdd;
        _scoreText.text = Score.ToString();

        /*int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings - 2)
        {
            HighScoreManager.SetHighScore(Score);
        }*/
    }

    public void ProcessPlayerDeath()
    {
        if(PlayerLives > 1)
        {
            TakeLive();
        }
        else
        {
            TryAgain.gameObject.SetActive(true);
            _audioPlayer.PlayTada();

            Invoke("ResetGame", 2.2f);
        }
    }

    public void AddLive(int pointsToAdd)
    {
        if (PlayerLives < 3)
        {
            PlayerLives++;
            _live.AddHeart();
        }
    }

    private void ResetGame()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    private void TakeLive()
    {
        PlayerLives--;
        _live.HeartDamage();
        //livesText.text = playerLives.ToString();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
