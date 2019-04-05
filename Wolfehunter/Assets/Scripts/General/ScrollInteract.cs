using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollInteract : MonoBehaviour
{
    [SerializeField] GameObject firstRiddle;
    [SerializeField] GameObject interactText;
    
    bool inRange;
    bool letterIsRead;

    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        firstRiddle.SetActive(false);
        inRange = false;
        letterIsRead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action") && inRange && !letterIsRead)
        {
            firstRiddle.SetActive(true);
            interactText.SetActive(false);
            letterIsRead = true;
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Action") || Input.GetButtonDown("Cancel") && letterIsRead)
        {
            firstRiddle.SetActive(false);
            interactText.SetActive(true);
            Time.timeScale = 1f;
            letterIsRead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactText.SetActive(true);
            inRange = true;
            
        }           
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactText.SetActive(false);
            inRange = false;
        }
    }
}
