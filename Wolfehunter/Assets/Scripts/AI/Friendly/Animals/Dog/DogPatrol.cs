// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class DogPatrol : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Transform[] points;

    private int destPoint = 0;
    private bool nearTarget;

    private DogInteract quest;
    private DialogueManager dialogue;
    private NavMeshAgent agent;
    private Animator anim;
    private UIManager ui;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogue = GetComponent<DialogueManager>();
        anim = GetComponent<Animator>();
        quest = FindObjectOfType<DogInteract>();
        ui = FindObjectOfType<UIManager>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        GotoNextPoint();
    }

    public void GotoNextPoint()
    {

        agent.stoppingDistance = 0f;
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        anim.SetBool("walk", true);
    }

    //When player runs away from dog after interacting
    public void ResetTarget()
    {
        dialogue.EndDialogue();
        nearTarget = false;
        GotoNextPoint();
    }

    void GotoTarget()
    {
        if (!nearTarget)
        {
            agent.stoppingDistance = 1.65f;

            agent.destination = target.position;
            if (agent.remainingDistance < 1.70f)
            {
                nearTarget = true;
            }
        }
        else
        {
            dialogue.StartDialogue();
            
            anim.SetBool("walk", false);
            quest.StartQuest();
        }

    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && quest.Interacting == false )
        {
            GotoNextPoint();
        }
        
        else if (quest.Interacting == true)
        {
            GotoTarget();
        }
    }
}