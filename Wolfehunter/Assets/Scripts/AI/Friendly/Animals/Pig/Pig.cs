using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pig : Animal
{

	private Animator anim;
	private NavMeshAgent nav;
	private Player player;
	private RunAway runPoint;
    private bool running;
    int rand;
    // Start is called before the first frame update
    void Start()
    {
		//run = GameObject.Find("RunAway").GetComponent<RunAway()>;
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		player = FindObjectOfType<Player>();
        runPoint = FindObjectOfType<RunAway>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
	}

	protected override void Move()
	{
		if(nav != null && WithinRange(RunAwayRange) && !running)
		{
            anim.SetBool("walk", true);
            running = true;
            rand = Random.Range(0, 9);
            if (rand == 0)
            {
  
                nav.SetDestination(runPoint.Rp0.transform.position);
                //nav.SetDestination()
                Invoke("RunTimer", 3f);
            }
            if (rand == 1)
            {
                nav.SetDestination(runPoint.Rp1.transform.position);
                //nav.SetDestination()
                Invoke("RunTimer", 3f);
            }
            if (rand == 2)
            {
                nav.SetDestination(runPoint.Rp2.transform.position);
                //nav.SetDestination()
                Invoke("RunTimer", 3f);
            }
            if (rand == 3)
            {
                nav.SetDestination(runPoint.Rp3.transform.position);
                //nav.SetDestination()
                Invoke("RunTimer", 3f);
            }
            if (rand == 4)
            {
                nav.SetDestination(runPoint.Rp3.transform.position);
                Invoke("RunTimer", 3f);
            }
            if (rand == 5)
            {
                nav.SetDestination(runPoint.Rp4.transform.position);
                Invoke("RunTimer", 3f);
            }
            if (rand == 6)
            {
                nav.SetDestination(runPoint.Rp5.transform.position);
                Invoke("RunTimer", 3f);
            }
            if (rand == 7)
            {
                nav.SetDestination(runPoint.Rp6.transform.position);
                Invoke("RunTimer", 3f);
            }
            if (rand == 8)
            {
                nav.SetDestination(runPoint.Rp7.transform.position);
                Invoke("RunTimer", 3f);
            }
            // Use Rand to find random point in RunAway script
            // nav.SetDestination(
        }
        else
        {
          //  Debug.Log("hit else");
        }
		// Also , Use Navmesh to make move around the map within a small radius
	
	}


    private void RunTimer()
    {
        if (!WithinRange(RunAwayRange))
        {
            running = false;
            nav.SetDestination(this.transform.position);
            anim.SetBool("walk", false);
        }
        else
        {
            Invoke("RunTimer", 3f);
        }

    }
	public bool WithinRange(float range)
	{
		if (Vector3.Distance(player.transform.position, transform.position) < range) //range from method param
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
