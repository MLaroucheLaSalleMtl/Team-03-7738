using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttack : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Attacked");
            other.GetComponent<Player>().TakeDamage(50);
        }

        //player.CurrLife -= Damage;
        //canAttack = false;
        //Invoke("Reset", AtkSpeed);
    }
}
