using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadAssets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadAssets()
    {
        StartCoroutine(LoadAssetCoroutine());

    }

    IEnumerator LoadAssetCoroutine()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene(1);
    }
}
