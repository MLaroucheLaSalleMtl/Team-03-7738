// RandomPointOnNavMesh.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{

    [SerializeField] private float range = 10.0f;
    private bool pathing;
    private NavMeshAgent randNav;
    private Animator anim;
    private Vector3 point;

    private void Start()
    {
        anim = GetComponent<Animator>();
        randNav = GetComponent<NavMeshAgent>();
        InvokeRepeating("Pathing", 1f, 3.5f); // Check if path is completed every 3 seconds, and if so to assign a new one. More performant than calling every Update()
    }

    void Update()
    {

    }

    void Pathing()
    {

            if (randNav.remainingDistance <= randNav.stoppingDistance)
            {
                point = RandomNavPoint(range);
                if (Vector3.Distance(this.transform.position, point) >= 3)
                {
                    anim.SetBool("walk", true);
                    randNav.SetDestination(RandomNavPoint(5f));
                }
                else if (Vector3.Distance(this.transform.position, point) <= 1.65f)
                {
                    anim.SetBool("walk", false);
                   // quest.StartQuest();
                }
                else
                {
                    Pathing();
                }

            }
            else
            {
            anim.SetBool("walk", false);
        }

        
    }

    public Vector3 RandomNavPoint(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}