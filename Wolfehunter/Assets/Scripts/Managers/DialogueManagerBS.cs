using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerBS : MonoBehaviour
{
    [SerializeField] private string npcName;
    [SerializeField] private string[] sentence;
    [SerializeField] private string[] winSentence; //Used after quest completion
    [SerializeField] private string postSentence;
    [SerializeField] private bool objectiveReached;
    [SerializeField] private GameObject boneSword;
    [SerializeField] private GameObject wolfeBane;


    private bool dialogueStarted;
    private int index;
    private bool next;
    private bool questFinished;
    private bool rewardGiven;

    private DialogueTrigger1 exitTrigger;
    private CombatManager combat;
    private GameManager game;
    private UIManager ui;
    private bool read;
    [SerializeField] private Animator anim;

    public bool ObjectiveReached { get => objectiveReached; set => objectiveReached = value; }
    public bool RewardGiven { get => rewardGiven; set => rewardGiven = value; }

    // Start is called before the first frame update
    void Start()
    {
        exitTrigger = FindObjectOfType<DialogueTrigger1>();
        combat = FindObjectOfType<CombatManager>();
        game = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        NextSentence();
    }


    private void Timer()
    {
        read = true;
    }
    public void StartDialogue()
    {
        if (!questFinished)
        {
            if (!dialogueStarted && !ObjectiveReached)
            {
                read = false;
                Invoke("Timer", .75f);
                dialogueStarted = true;
                ui.QuestPanel.gameObject.SetActive(true);
                ui.DialoguePic.sprite = ui.WizardPic.sprite;
                ui.NpcName.text = npcName;
                StopAllCoroutines();
                StartCoroutine(CharAppear(sentence[index]));
            }
            else if (!dialogueStarted && ObjectiveReached)
            {
                read = false;
                Invoke("Timer", .75f);
                dialogueStarted = true;
                //anim.SetBool("Start", true);
                ui.QuestPanel.gameObject.SetActive(true);
                ui.DialoguePic.sprite = ui.WizardPic.sprite;
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
                read = false;
                Invoke("Timer", .75f);
                dialogueStarted = true;
                ui.QuestPanel.gameObject.SetActive(true);
                ui.DialoguePic.sprite = ui.WizardPic.sprite;
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
            if (dialogueStarted && Input.GetButtonDown("Action") && !ObjectiveReached && read == true)
            {
                ui.DialoguePic.sprite = ui.WizardPic.sprite;
                ui.NpcName.text = npcName;
                if (index < sentence.Length - 1)
                {
                    StopAllCoroutines();
                    index++;
                    StartCoroutine(CharAppear(sentence[index]));

                }
                else if (index == 2)
                {
                    ObjectiveReached = true;
                    ui.InfoText.text = "Received Wolfebane";
                    boneSword.gameObject.SetActive(false);
                    wolfeBane.gameObject.SetActive(true);
                    ui.FadePanel();
                    questFinished = true;
                    EndDialogue();
                    RewardGiven = true;
                    exitTrigger.Disable();
                    combat.UpdateWeapon();

                    // EndDialogue();
                }

            }
            else if (dialogueStarted && Input.GetButtonDown("Action") && ObjectiveReached)
            {
                ui.DialoguePic.sprite = ui.WizardPic.sprite;
                ui.NpcName.text = npcName;
                if (index < winSentence.Length - 1)
                {
                    StopAllCoroutines();
                    index++;
                    StartCoroutine(CharAppear(winSentence[index]));
                }
                else if(!RewardGiven)
                {
                    ui.InfoText.text = "Received Certificate";
                    ui.FadePanel();
                    game.HasWeapon = true;
                    questFinished = true;
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
