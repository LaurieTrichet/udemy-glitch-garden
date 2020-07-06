using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    private int currentSceneIndex = 0;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            LoadAssets();
        }
    }


    void LoadAssets()
    {
        StartCoroutine(LoadAssetCoroutine());
    }

    IEnumerator LoadAssetCoroutine()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        var nextIndex = currentSceneIndex + 1;
        if (nextIndex <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("no more levels");
        }
    }


    IEnumerator LoadAssetCoroutineForIndex(int index)
    {
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene( index);
    }

    internal void RestartLevel()
    {
        StartCoroutine(LoadAssetCoroutineForIndex(currentSceneIndex));
    }

    internal void GoToMenu()
    {
        StartCoroutine(LoadAssetCoroutineForIndex(1));
    }

    public void GoToFirstLevel()
    {
        StartCoroutine(LoadAssetCoroutineForIndex(2));
    }    
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
 