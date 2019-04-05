using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSwordHit : MonoBehaviour
{
    private Player player;
    private Vector3 hitPoint;
    private FreezeFeedback freeze;
    private Vector3 impulse = new Vector3(5.0f, 0f, 5.0f);// chagne values

    [SerializeField] private GameObject hitParticle;

    private CombatManager combat;

    // Start is called before the first frame update
    void Start()
    {
        combat = FindObjectOfType<CombatManager>();
        player = FindObjectOfType<Player>();
        freeze = GetComponent<FreezeFeedback>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Creature")
        {
            if (other.GetComponent<Enemy>().HasBeenHit == false)
            {
                hitPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
                Instantiate(hitParticle, hitPoint, player.transform.rotation);
                other.GetComponent<Enemy>().TakeDamage(100);
                other.GetComponent<Enemy>().HasBeenHit = true;
                other.GetComponent<Enemy>().ResetAtk();
                other.GetComponent<Enemy>().GetHit();
                //other.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
                freeze.Freeze();
            }
        }
    }

    
}
