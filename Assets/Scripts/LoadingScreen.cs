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
        SceneManager.LoadScene(currentSceneIndex+1);
    }


    public void LoadGameOver()
    {
        StartCoroutine(LoadAssetCoroutineForIndex(1));
    }

    IEnumerator LoadAssetCoroutineForIndex(int index)
    {
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene( index);
    }
}
 