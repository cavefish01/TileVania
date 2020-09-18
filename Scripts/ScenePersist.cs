using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{

    int sceneNum;

     // Singleton  "THERE CAN ONLY BE ONE"
    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
    
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        sceneNum = GetStartingSceneIndex();
    }

    public int GetStartingSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCurrentScene();
    }

    private void CheckCurrentScene()
    {
        int currentSceneNum = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneNum != sceneNum)
        {
            Destroy(gameObject);
        }
    }

    public void KillScenePersist()
    {
        Destroy(gameObject);
    }
}
