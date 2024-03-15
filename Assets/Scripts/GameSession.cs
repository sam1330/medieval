using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    // Configs
    [SerializeField] int playerLives = 3;
    [SerializeField] float loadLevelDelay = 1f;

    // Cached references
    [SerializeField] Text livesText = default;
    [SerializeField] Text scoreText = default;

    // State
    int score = 0;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
            TakeLife();
        else
            RestartGameSession();
    }

    private void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadLevel(currentSceneIndex));
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        yield return new WaitForSecondsRealtime(loadLevelDelay);
        SceneManager.LoadScene(sceneIndex);
    }

    private void RestartGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
