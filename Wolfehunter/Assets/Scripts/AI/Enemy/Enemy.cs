using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float atkSpeed;
    [SerializeField] private float atkRange;
    [SerializeField] private float chaseRange;
    //[SerializeField] private GameObject PopUpDamage;

    private bool hasBeenHit;
    private bool dead;

    public float Health { get => health; set => health = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float Damage { get => damage; set => damage = value; }
    public float AtkRange { get => atkRange; set => atkRange = value; }
    public float AtkSpeed { get => atkSpeed; set => atkSpeed = value; }
    public float ChaseRange { get => chaseRange; set => chaseRange = value; }
    public bool HasBeenHit { get => hasBeenHit; set => hasBeenHit = value; }
    public bool Dead { get => dead; set => dead = value; }

    //Methods to override per enemy
    protected abstract void Attack();
    protected abstract void Move();
    public abstract void GetHit();

    public void TakeDamage(float damage)
    {
        if (Health >= 0)
        {
            Health -= damage;
            //if (PopUpDamage)
            //{
            //    ShowPopUpDamage();
            //}
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }
        else
        {
            Health = 0;
            Die();
        }
    }
    private void ShowPopUpDamage()
    {
     //   var go = Instantiate(PopUpDamage, transform.position, Quaternion.identity, transform);
      //  go.GetComponent<TextMesh>().text = health.ToString();
    }

    public void Die()
    {
        Invoke("Delete", .275f); 

        //ragdoll blowup effect if spell ? override maybe

    }

    private void Delete()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Dead");
        Destroy(this.gameObject);
    }
    public void ResetAtk()
    {
        Invoke("ResetHit", .125f);
    }

    private void ResetHit()
    {
        HasBeenHit = false;
    }
}
