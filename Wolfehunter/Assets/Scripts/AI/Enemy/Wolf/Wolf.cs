using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : Enemy
{
    [SerializeField] private ParticleSystem deathEffect;
    private Vector3 hitPoint;
    private GameManager game;
    private Animator anim;
    private NavMeshAgent nav;
    private Player player;
    private bool onlyOnce;
    private bool canAttack = true;
    private bool attacking;

    private bool fov;
    [SerializeField] private BoxCollider attackCol;

    void Start()
    {
        game = FindObjectOfType<GameManager>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();

    }

    private void Update()
    {       
        CheckStatus();
        Move();
        Attack();
    }

    protected override void Move()
    {
        if (nav != null && WithinRange(ChaseRange) && !attacking ) //maybe put in enemy? 
        {
            SetPath(); // Start chasing
        }
        //else if (fov)
        //{
        //        anim.SetBool("move", false);
        //        nav.SetDestination(this.transform.position); // Stop walking towards player  
        //}
        //else if (!fov)
        //{
        //    SetPath();
        //}
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
    private void CheckStatus()
    {
        if (Health <= 0 && !onlyOnce)
        {
            onlyOnce = true;
            hitPoint = this.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            Destroy(Instantiate(deathEffect, hitPoint, Quaternion.Euler(270, 3, 0)), 2);
            game.WolfKill += 1;
        }
    }

    protected override void Attack()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < AtkRange)
        {

            if (canAttack == true && !attacking)
            {

                StartCoroutine(EnemyTurn());
            }
        }
    }

    void Attacking()
    {
        anim.SetTrigger("Attack");
        attacking = true;
    }

    IEnumerator EnemyTurn()
    {
        Quaternion newDir = Quaternion.LookRotation(player.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newDir, 1.5f * Time.deltaTime);
        if (this.transform.rotation == newDir)
        {
            Attacking();
        }
        else
        {
            yield return new WaitForSeconds(2f);
            Attacking();
        }
    }

    //From attack animation event
    private void DoDamage(int n)
    {
        //start of anim
        if (n == 0)
        {
            attackCol.enabled = true;
            anim.SetBool("move", false);
            nav.SetDestination(this.transform.position);
        }

        //end of anim
        else if (n == 1)
        {
            attacking = false;
            attackCol.enabled = false;
            SetPath();
        }

    }

    private void SetPath()
    {
        if (player != null)
        {
            anim.SetBool("move", true);

            Vector3 target = player.transform.position;
            //transform.LookAt(target); No need
            nav.SetDestination(target);
           /* if (!fov)
            {
                Invoke("LateRotate", 2.5f);
                
            }*/     
        }
    }

    private void Reset()
    {
        canAttack = true;
    }

    public override void GetHit()
    {

        anim.SetTrigger("IsHit");
        canAttack = false;
        Invoke("Reset", 1f);
    }
}
