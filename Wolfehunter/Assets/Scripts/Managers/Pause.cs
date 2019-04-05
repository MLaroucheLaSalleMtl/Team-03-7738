using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel; 
    //[SerializeField] private GameObject loadingPanel;
    //[SerializeField] private Slider loadingBar;
    private bool pause = false;


    public void SaveGame()
    {
        Debug.Log("Saved Game");
    }
    //Return Menu

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    //Quit
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    //Pause game
    public void PauseGame()
    {
        PausePanel.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        PausePanel = GameObject.Find("PausePanel");
        //loadingPanel = GameObject.Find("LoadingPanel");
        PausePanel.SetActive(false);
        //loadingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Pause Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                Time.timeScale = 1.0f;
                PausePanel.SetActive(false);
                pause = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                PausePanel.SetActive(true);
                pause = true;
            }
        }
    }
}
