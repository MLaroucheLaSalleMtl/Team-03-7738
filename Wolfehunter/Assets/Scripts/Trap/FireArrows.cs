using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrows : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;

    public bool test;


    private void Update()
    {
        if (test)
        {
            Invoke("Fire", 2f);
            Instantiate(arrow, target.transform);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;

        }
    }

    public void Fire()
    {
        if (test)
        {
            Invoke("Fire", 2f);
            Instantiate(arrow, target.transform);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;

        }

    }

}
