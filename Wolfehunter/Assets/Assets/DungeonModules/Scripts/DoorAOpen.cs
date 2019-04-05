using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAOpen : MonoBehaviour
{
    [SerializeField] GameObject interactText;
    public Animator anim;
    [SerializeField] private GameObject player;

    bool inRange;
    bool isOpen;

    // Use this for initialization
    void Start()
    {
        isOpen = false;
        inRange = false;
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action") && inRange && !isOpen)
        {
            //anim.Play();
            isOpen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player && !isOpen)
        {
            Debug.Log("IsTrigger");
            interactText.SetActive(true);
            inRange = true;
            anim.SetTrigger("DoorATrigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            interactText.SetActive(false);
            inRange = false;
            anim.SetTrigger("DoorATrigger");
        }
    }
}