using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithinRangeBone : MonoBehaviour
{
    bool inRange;

    private UIManager ui;
    private GameManager game;
    private DialogueManager dialogue;
    [SerializeField] private GameObject boneArea;
    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        game = FindObjectOfType<GameManager>();
        dialogue = GameObject.FindWithTag("Dog").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetButtonDown("Action") && !game.HasBone)
        {
            game.HasBone = true;
            dialogue.ObjectiveReached = true;
            ui.InteractText.gameObject.SetActive(false);
            boneArea.gameObject.SetActive(false);
            
            ui.InfoText.text = "Picked up bone";
            ui.FadePanel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !game.HasBone)
        {
            inRange = true;
            ui.InteractText.gameObject.SetActive(true);
            ui.InteractText.text = "Interact - Dig up bone";

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
            ui.InteractText.gameObject.SetActive(false);
        }
    }
}
