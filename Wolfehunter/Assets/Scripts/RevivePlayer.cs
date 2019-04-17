using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePlayer : MonoBehaviour
{
    private int lives = 5;
    private UIManager ui;
    private Player player;
    [SerializeField] private Animator anim;

    public int Lives { get => lives; set => lives = value; }

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Revive()
    {
        if(Lives > 0)
        {
            ui.MenuButton.gameObject.SetActive(false);
            player.CheckDead = false;
            Lives--;
            player.CurrLife = 300;
            player.MaxLife = 300;
            anim.SetTrigger("Revive");
            Time.timeScale = 1f;
            Invoke("Disable", 1.5f);
        }

    }

    private void Disable()
    {
        ui.DeathPanel.gameObject.SetActive(false);

    }
}
