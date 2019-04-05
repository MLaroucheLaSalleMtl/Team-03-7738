using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteract : MonoBehaviour
{
    private bool interacting;
    private bool inRange;
    private bool questStarted;

    public bool Interacting { get => interacting; set => interacting = value; }

    private DogPatrol patrol;
    private UIManager ui;
    [SerializeField] AudioSource dogBark;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        patrol = FindObjectOfType<DogPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetButtonDown("Action") && !Interacting)
        {
            dogBark.Play();
            ui.InteractText.gameObject.SetActive(false);
            Interacting = true;
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
        if(other.gameObject.tag == "Player")
        {
            ui.InteractText.text = "Interact - Talk with Dog";
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
            patrol.ResetTarget();
        }
    }
}
