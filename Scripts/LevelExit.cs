using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float waitToLoadNextScene = 2f;
    [SerializeField] float slowMoFactor = 0.2f;
    bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasTriggered)
        {
            FindObjectOfType<ScenePersist>().KillScenePersist();
            StartCoroutine(LoadNextScene());
            hasTriggered = true;
        }
    }

    IEnumerator LoadNextScene()
    {
        Time.timeScale = slowMoFactor;
        yield return new WaitForSecondsRealtime(waitToLoadNextScene);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
