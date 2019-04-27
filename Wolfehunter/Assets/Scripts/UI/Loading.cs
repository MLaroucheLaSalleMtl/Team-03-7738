using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private AsyncOperation async;
    void Start()
    {
        LoadScene(2);
    }

    public void LoadScene(int n)
    {
        if (async == null)
        {
            Time.timeScale = 1;
            async = SceneManager.LoadSceneAsync(n);
            async.allowSceneActivation = true;
        }


    }
}
