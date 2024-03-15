using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    // // State
    // int startSceneBuildIndex;

    // void Awake()
    // {
    //     var numScenePersist = FindObjectsOfType<ScenePersist>().Length;
    //     if (numScenePersist > 1)
    //         Destroy(gameObject);
    //     else
    //         DontDestroyOnLoad(gameObject);
    // }

    // // Start is called before the first frame update
    // void Start()
    // {
    //     startSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     var currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    //     if (currentSceneBuildIndex != startSceneBuildIndex)
    //         Destroy(gameObject);
    // }


/*
    Following Code was copied from:
        https://www.udemy.com/course/unitycourse/learn/lecture/10360636#questions/4338832
*/

    static ScenePersist instance = null;
    int startingSceneIndex;    
 
    void Start() {  
        if (!instance) { 
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }
 
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(startingSceneIndex != SceneManager.GetActiveScene().buildIndex) {
            instance = null;
            SceneManager.sceneLoaded -= OnSceneLoaded;           
            Destroy(gameObject);
        }
    }
}
