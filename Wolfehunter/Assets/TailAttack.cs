using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailAttack : MonoBehaviour
{
    private CombatManager player;
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
        if (other.gameObject.tag == "Player" && !player.Rolling)
        {
            Debug.Log("Attacked");
            other.GetComponent<Player>().TakeDamage(75);
        }

        //player.CurrLife -= Damage;
        //canAttack = false;
        //Invoke("Reset", AtkSpeed);
    }
}
