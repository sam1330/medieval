using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float slowMoTime = 0.3f;

    // State
    bool loadingLevel = false;

    void OnTriggerEnter2D()
    {
        if (loadingLevel) { return; }
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        loadingLevel = true;

        // Make timelaps effect
        var oldTimeScale = Time.timeScale;
        Time.timeScale *= slowMoTime;

        yield return new WaitForSecondsRealtime(levelLoadDelay);

        // Revert to old game speed
        Time.timeScale = oldTimeScale;

        // Load next level
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
    }
}
