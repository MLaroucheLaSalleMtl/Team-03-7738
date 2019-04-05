using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithinRangeStatue : MonoBehaviour
{
    [SerializeField] private Animator gateAnim;
    [SerializeField] private Animator anim;
    [SerializeField] AudioSource gateOpen;
    private GameManager game;
    private UIManager ui;
    private bool inRange;
    private bool trigger;
    private bool complete;

    public bool InRange { get => inRange; set => inRange = value; }

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange && Input.GetButton("Action") && !trigger && !complete)
        {
            trigger = true;
            ui.InteractText.gameObject.SetActive(false);
            ui.FangPanel.gameObject.SetActive(true);
            if (game.WolfKill == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Color temp = ui.Fang[i].color;
                    temp = Color.white;
                    ui.Fang[i].color = temp;
                }
                //open gate
                complete = true;
                Invoke("ClosePanel", 2.25f);
                gateOpen.Play();
                gateAnim.SetBool("Open", true);

            }
            else if (game.WolfKill == 4)
            {
                for (int i =0; i < 4; i++)
                {
                    Color temp = ui.Fang[i].color;
                    temp = Color.white;
                    ui.Fang[i].color = temp;
                }
            }
            else if (game.WolfKill == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Color temp = ui.Fang[i].color;
                    temp = Color.white;
                    ui.Fang[i].color = temp;
                }
            }
            else if (game.WolfKill == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    Color temp = ui.Fang[i].color;
                    temp = Color.white;
                    ui.Fang[i].color = temp;
                }
            }
            else if (game.WolfKill == 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    Color temp = ui.Fang[i].color;
                    temp = Color.white;
                    ui.Fang[i].color = temp;
                }
            }

        }
    }

    private void ClosePanel()
    {
        anim.SetBool("Start", false);
        Invoke("Disable", 2f);
        trigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !complete)
        {
            InRange = true;
            ui.InteractText.text = "Interact - View Statue"; //INPUT MANAGER
            ui.InteractText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trigger = false;
            InRange = false;
            anim.SetBool("Start", false);
            Invoke("Disable", 1f);
            ui.InteractText.gameObject.SetActive(false);
        }
    }

    private void Disable()
    {
        ui.FangPanel.gameObject.SetActive(false);
    }
}
