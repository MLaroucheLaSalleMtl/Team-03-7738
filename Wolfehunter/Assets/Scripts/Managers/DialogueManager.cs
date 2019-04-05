using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private string npcName;
    [SerializeField] private string[] sentence;
    [SerializeField] private string[] winSentence; //Used after quest completion
    [SerializeField] private string postSentence;
    [SerializeField] private bool objectiveReached;
    [SerializeField] private GameObject boneSword;

    private bool dialogueStarted;
    private int index;
    private bool next;
    private bool questFinished;

    private GameManager game;
    private UIManager ui;
    [SerializeField] private Animator anim;

    public bool ObjectiveReached { get => objectiveReached; set => objectiveReached = value; }

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        NextSentence();
    }

    public void StartDialogue()
    {
        if (!questFinished)
        {
            if (!dialogueStarted && !ObjectiveReached)
            {
                dialogueStarted = true;
                ui.QuestPanel.gameObject.SetActive(true);
                ui.NpcName.text = npcName;
                StopAllCoroutines();
                StartCoroutine(CharAppear(sentence[index]));
            }
            else if (!dialogueStarted && ObjectiveReached)
            {
                dialogueStarted = true;
                //anim.SetBool("Start", true);
                ui.QuestPanel.gameObject.SetActive(true);
                ui.NpcName.text = npcName;
                StopAllCoroutines();
                index = 0;
                StartCoroutine(CharAppear(winSentence[index]));
            }
        }
        else
        {
            if (!dialogueStarted)
            {
                dialogueStarted = true;
                ui.QuestPanel.gameObject.SetActive(true);
                ui.NpcName.text = npcName;
                StopAllCoroutines();
                StartCoroutine(CharAppear(postSentence));
            }

        }

    }

    public void NextSentence()
    {
        if (!questFinished)
        {
            if (dialogueStarted && Input.GetButtonDown("Action") && !ObjectiveReached)
            {
                if (index < sentence.Length - 1)
                {
                    StopAllCoroutines();
                    index++;
                    StartCoroutine(CharAppear(sentence[index]));

                }
                else
                {
                   // EndDialogue();
                }

            }
            else if (dialogueStarted && Input.GetButtonDown("Action") && ObjectiveReached)
            {
                if (index < winSentence.Length - 1)
                {
                    StopAllCoroutines();
                    index++;
                    StartCoroutine(CharAppear(winSentence[index]));
                }
                else if(!game.HasWeapon)
                {
                    ui.InfoText.text = "Received Bone Sword";
                    ui.FadePanel();
                    game.HasWeapon = true;
                    questFinished = true;
                    boneSword.gameObject.SetActive(true);
                    EndDialogue();
                }

            }
        }

    }
    public void EndDialogue()
    {
        StopAllCoroutines();
        anim.SetBool("Start", false);
        dialogueStarted = false;
        Invoke("Disable", 1f);
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

    //Wait for animation
    private void Disable()
    {
        ui.QuestPanel.gameObject.SetActive(false);
    }

}
