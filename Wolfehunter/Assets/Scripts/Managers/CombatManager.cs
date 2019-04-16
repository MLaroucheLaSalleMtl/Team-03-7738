using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private GameManager game;
    private Player player;
    private AnimManager animM;

    private Animator anim;
    private bool blocking;
    private bool rollLock;

    private bool rolling;
    private bool canCombo;
    private bool attacking;
    private bool inCombo;

    [SerializeField] BoxCollider swordCollider;
    [SerializeField] ParticleSystem trail;

    [SerializeField] BoxCollider swordCollider2;
    [SerializeField] ParticleSystem trail2;
    [SerializeField] AudioSource woosh;

    public bool Blocking { get => blocking; set => blocking = value; }
    public bool Rolling { get => rolling; set => rolling = value; }

    public void UpdateWeapon()
    {
        swordCollider = swordCollider2;
        trail = trail2;
    }

    void Start()
    {
        player = GetComponent<Player>();
        animM = GetComponent<AnimManager>();
        anim = GetComponent<Animator>();
        game = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageCombat();
    }

    public void Woosh()
    {
        woosh.Play();
    }

    public void ManageCombat()
    {
        if (attacking && Input.GetButtonDown("Attack") && !inCombo)
        {
            if (player.CurrStamina >= 5)
            {
                player.CurrStamina -= 2.5f;
                inCombo = true;
                anim.SetTrigger("Combo");
            }

        }
        /*  if (Input.GetKeyDown(KeyCode.LeftShift))
          {
              anim.SetTrigger("Blocking");    
          }
          if (Input.GetKey(KeyCode.LeftShift))
      {
          anim.SetBool("HoldBlock", true);
      }
          else if (Input.GetKeyUp(KeyCode.LeftShift))
          {
              anim.SetBool("HoldBlock", false);
              Blocking = false;
          }

      if (Input.GetKeyDown("e"))
      {
          anim.SetBool("HasShield", false);
      }*/

        if (Input.GetButtonDown("Dodge"))
        {
            if (player.CurrStamina >= 3)
            {
                anim.SetTrigger("Roll");
            }

        }
        if (Input.GetButtonDown("Attack") && game.HasWeapon)
        {
            if (player.CurrStamina >= 3 && !attacking)
            {
                woosh.Play();
                attacking = true;
                anim.SetTrigger("Attack");
            }
        }
    }


    //Animation events -----------------------
    public void TriggerRoll()
    {
        Rolling = true;
        player.CurrStamina -= 3;
    }
    public void StopRoll()
    {
        Rolling = false;
    }
    public void TriggerActive(int n) // Attack
    {
        if (n == 0)
        {
            swordCollider.enabled = true;
            trail.Play();
            player.CurrStamina -= 2; // why is it reducing double ...
            canCombo = true;

        }
        else if (n == 1 && !inCombo)
        {
            canCombo = false;
            attacking = false;
            swordCollider.enabled = false;
            trail.Stop();
        }
    }

    public void EndCombo()
    {
        canCombo = false;
        attacking = false;
        inCombo = false;
        swordCollider.enabled = false;
        trail.Stop();
    }

}

