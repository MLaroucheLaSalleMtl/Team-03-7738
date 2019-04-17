using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private GameObject loadingText;

    IEnumerator LoadAsynchronously(string Scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Scene);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.value = progress;
            yield return null;
        }
    }
   

    void Start()
    {
        loadingText = GameObject.Find("LoadingText");
    }
    
    void LateUpdate()
    {
        if (Input.anyKey)
        {
            loadingText.GetComponent<Text>().text = "Loading...";
            StartCoroutine(LoadAsynchronously("MainScene"));
        }
    }
}
