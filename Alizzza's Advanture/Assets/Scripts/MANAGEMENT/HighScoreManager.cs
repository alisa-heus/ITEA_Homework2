using UnityEngine;

public static class HighScoreManager
{
    // The key used to save and load the high score
    private const string HighScoreKey = "HighScore";
    // The current high score
    private static int _currentHighScore;

    // Call this method when the player achieves a new high score
    public static void SetHighScore(int newScore)
    {
        if (newScore > _currentHighScore)
        {
            _currentHighScore = newScore;
            SaveHighScore();

            Debug.Log("New High Score: " + _currentHighScore);
        }
    }

    // Save the high score to PlayerPrefs
    private static void SaveHighScore()
    {
        PlayerPrefs.SetInt(HighScoreKey, _currentHighScore);
        PlayerPrefs.Save();
    }

    // Load the high score from PlayerPrefs
    private static void LoadHighScore()
    {
        // If the key exists, load the high score; otherwise, use a default value (e.g., 0)
        _currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        Debug.Log("Loaded High Score: " + _currentHighScore);
    }
}
