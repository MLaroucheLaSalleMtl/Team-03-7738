using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool hasBone;
    private bool hasWeapon;

    [SerializeField] private int wolfKill;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject hudCanvas;

    // [SerializeField] GameObject firstRiddle;
    // [SerializeField] GameObject firstRiddleInscription;

    public bool HasWeapon { get => hasWeapon; set => hasWeapon = value; }
    public bool HasBone { get => hasBone; set => hasBone = value; }
    public int WolfKill { get => wolfKill; set => wolfKill = value; }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
       // firstRiddle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseMenu();
        }
    }

    void PauseMenu()
    {
        if (pauseMenu.activeSelf == false)
        {
            hudCanvas.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            hudCanvas.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
