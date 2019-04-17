using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private bool interacting;
    private bool inRange;
    private bool questStarted;
    private bool cooldown;

    public bool Interacting { get => interacting; set => interacting = value; }

    private UIManager ui;
    private Player player;
    [SerializeField] private ParticleSystem flies;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UIManager>();
    }
    void Cooldown()
    {
        cooldown = false;
        flies.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetButtonDown("Action") && !Interacting && !cooldown) 
        {
            ui.InteractText.gameObject.SetActive(false);
            Interacting = true;
            player.CurrLife = 300;
            player.MaxLife = 300;
            cooldown = true;
            flies.Stop();
            Invoke("Cooldown", 30f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !cooldown && player.CurrLife != 300)
        {
            ui.InteractText.text = "Interact - Drink from fountain";
            ui.InteractText.gameObject.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
            Interacting = false;
            ui.InteractText.gameObject.SetActive(false);

        }
    }
}
