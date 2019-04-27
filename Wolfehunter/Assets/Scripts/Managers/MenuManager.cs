using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private AsyncOperation async;
    /* Summary : Class that control 
     * the Menu scene
    *//*
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject BackGround;
    [SerializeField] private GameObject TextSetting;
    [SerializeField] private GameObject TextName;*/

    //Option Panel Animation
    /* public void DisableBoolInAnimator(Animator anim)
     {
         BackGround.SetActive(false);
         anim.SetBool("isDisplayed", false);
     }
     public void EnableBoolInAnimator(Animator anim)
     {
         BackGround.SetActive(true);
         anim.SetBool("isDisplayed", true);
     }*/



    public void Load(string scene)
    {
       // SceneManager.LoadSceneAsync(scene);
    }

    public void StartGame(int i)
    {
        if (async == null)
        {
            Time.timeScale = 1;
            async = SceneManager.LoadSceneAsync(i);
            async.allowSceneActivation = true;
        }

    }
    /*public void TestGame()
    {
        Load("MainScene");
    }*/

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }



    void Start()
    {
        /*optionPanel = GameObject.Find("OptionPanel");
        BackGround = GameObject.Find("BackGround");
        TextName = GameObject.Find("BrandName");
        TextSetting = GameObject.Find("TextSetting");
        BackGround.SetActive(false);*/
    }
    void Update()
    {
        /* if (Input.GetKey(KeyCode.Escape))
         {
             BackGround.SetActive(false);
         }*/
    }
}
