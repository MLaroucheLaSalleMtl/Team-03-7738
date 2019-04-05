using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateTurret()
    {
        turret.GetComponent<Animator>().SetTrigger("TurnOn");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Activate");
            Invoke("ActivateTurret", .75f);
            //enable shooting script
        }
    }
}
