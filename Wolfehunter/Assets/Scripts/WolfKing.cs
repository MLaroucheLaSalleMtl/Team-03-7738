using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfKing : Enemy
{
    [SerializeField] private ParticleSystem deathEffect;
    private Vector3 hitPoint;
    private GameManager game;
    private Animator anim;
    private NavMeshAgent nav;
    private Player player;
    private UIManager ui;
    private bool onlyOnce;
    private bool canAttack = true;
    private bool attacking;
    private bool displayHP;

    private bool fov;
    [SerializeField] private BoxCollider attackCol;
    [SerializeField] private GameObject smashZone;
    

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
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
        if (displayHP)
        {
            ui.WolfKingHP.fillAmount = Health / MaxHealth;
        }

        if(Health <= 0)
        {
            Invoke("GameOver",1f);
            ui.WinPanel.gameObject.SetActive(true);
            ui.WolfKingHPObj.gameObject.SetActive(false);
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
    }
    protected override void Move()
    {
        if (nav != null && WithinRange(ChaseRange) && !attacking) //maybe put in enemy? 
        {
            SetPath(); // Start chasing
            ui.WolfKingHPObj.gameObject.SetActive(true);
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
            if (!displayHP)
            {
                displayHP = true;
                
            }
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
        canAttack = false;
        
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
    private void DoSmash(int n)
    {
        //start of anim
        if (n == 0)
        {
            attackCol.enabled = true;
            anim.SetBool("move", false);
            canAttack = false;
            nav.SetDestination(this.transform.position);
        }

        //end of anim
        else if (n == 1)
        {
            attacking = false;
            attackCol.enabled = false;
            Invoke("ResetSmash", 0.75f);
        }

    }

    private void ShowZone()
    {
        smashZone.gameObject.SetActive(true);
    }

    private void ResetSmash()
    {
        smashZone.gameObject.SetActive(false);
        canAttack = true;
        SetPath();
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

    }
}
