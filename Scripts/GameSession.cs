using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] float waitForDeath = 1f;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] int levelOneBuildIndex;

    int levelNum;


    // Singleton  "THERE CAN ONLY BE ONE"
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }       
    }

    private void Update()
    {
        DetermineLevelNum();
    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }



    public void DetermineLevelNum()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex - levelOneBuildIndex + 1;
        levelText.text = levelNum.ToString();
    }


    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void AddToLives(int livesToAdd)
    {
        playerLives += livesToAdd;
        livesText.text = playerLives.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives >= 1)
        {
            TakeLife();
        }
        else
        {
           // SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            ResetGameSession();
        }
    }

    public void KillGameSession()
    {
        Destroy(gameObject);
    }

    private void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
        StartCoroutine(DeathWait());
    }

    IEnumerator DeathWait()
    {
        yield return new WaitForSecondsRealtime(waitForDeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ResetGameSession()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
   //     Destroy(gameObject);
    }
}
