using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDetect : MonoBehaviour
{
    [SerializeField] private CapsuleCollider bushCol;
    private CombatManager player;
    [SerializeField] private Animator anim;
    private bool onlyOnce;
    // Start is called before the first frame update
    void Start()
    {
       
        player = FindObjectOfType<CombatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && player.Rolling == true)
        {
            anim.SetTrigger("Rustle");
            bushCol.enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && player.Rolling == true && !onlyOnce)
        {
            onlyOnce = true;
            anim.SetTrigger("Rustle");
            bushCol.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        onlyOnce = false;
        bushCol.enabled = true;
    }
}
