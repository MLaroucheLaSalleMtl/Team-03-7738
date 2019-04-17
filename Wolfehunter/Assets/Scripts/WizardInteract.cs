using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardInteract : MonoBehaviour
{
    private bool interacting;
    private bool inRange;
    private bool questStarted;

    public bool Interacting { get => interacting; set => interacting = value; }

    private UIManager ui;
    private DialogueManagerWizard wizard;

    // Start is called before the first frame update
    void Start()
    {
        wizard = FindObjectOfType<DialogueManagerWizard>();
        ui = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetButtonDown("Action") && !Interacting)
        {
            ui.InteractText.gameObject.SetActive(false);
            Interacting = true;
            wizard.StartDialogue();
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
        if (other.gameObject.tag == "Player")
        {
            ui.InteractText.text = "Interact - Talk with Wizard";
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
            wizard.EndDialogue();

        }
    }
}
