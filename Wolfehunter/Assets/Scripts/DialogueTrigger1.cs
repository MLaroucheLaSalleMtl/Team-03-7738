using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger1 : MonoBehaviour
{
    private UIManager ui;
    [SerializeField] private Animator anim;
    private bool onlyOnce;
    [SerializeField] private string[] sentences;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
    }


    public void Disable()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && !onlyOnce)
        {
            onlyOnce = true;
            ui.DialoguePic.sprite = ui.SelfPic.sprite;
            ui.NpcName.text = "You";
            StopAllCoroutines();
            StartCoroutine(CharAppear(sentences[0]));
            ui.TriggerDialogue();
            Invoke("EndDialogue", 3f);
        }
    }


    IEnumerator CharAppear(string text)
    {
        ui.DialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            ui.DialogueText.text += letter;
            yield return new WaitForSecondsRealtime(.0125f);
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        anim.SetBool("Start", false);
        Invoke("DisablePanel", 1f);
    }

    private void DisablePanel()
    {
        ui.QuestPanel.gameObject.SetActive(false);
    }

}
