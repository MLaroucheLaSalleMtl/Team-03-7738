using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{

    //ALL GETKEYDOWN NEED TO BE GETBUTTONDOWN at end
    //Will need to configure inputmanager

    private GameManager game;

    private Animator anim;


    private void Awake()
    {
        game = GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }
    public void Move()
    {

        Attack();
        Craft();
        Gather();
        Melee();
        Cut();
    }
    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SetAnim("Punch");
        }
    }

    public void Cut()
    {
        GetKeyAnim("h", "Cut");
    }
    public void Craft()
    {
        GetKeyAnim("j", "Craft");
    }
    public void Gather()
    {
        GetKeyAnim("k", "Gather");
    }
    public void Melee()
    {
        GetKeyAnim("l", "Melee");
    }

    public void GetKeyAnim(string key, string nameAnim)
    {
        if (Input.GetKeyDown(key))
        {
            SetAnim(nameAnim);
        }
    }
    public void SetAnim(string nameAnim)
    {
        anim.SetTrigger(nameAnim);
    }
}
