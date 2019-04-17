using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithInteract : MonoBehaviour
{
    private bool interacting;
    private bool inRange;
    private bool questStarted;

    public bool Interacting { get => interacting; set => interacting = value; }

    private UIManager ui;
    private DialogueManagerBS smith;
    private DialogueManagerMayor mayor;

    // Start is called before the first frame update
    void Start()
    {
        smith = FindObjectOfType<DialogueManagerBS>();
        mayor = FindObjectOfType<DialogueManagerMayor>();
        ui = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetButtonDown("Action") && !Interacting)
        {
            ui.InteractText.gameObject.SetActive(false);
            Interacting = true;
            smith.StartDialogue();
        }
    }

    public void StartQuest()
    {
        if (!questStarted)
        {
            Debug.Log("Quest started");
            questStarted = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && mayor.RewardGiven)
        {
            ui.InteractText.text = "Interact - Talk with Blacksmith";
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
            smith.EndDialogue();

        }
    }
}
