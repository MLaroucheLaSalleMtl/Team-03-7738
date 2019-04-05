using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{

	[SerializeField] private float maxHealth;
	[SerializeField] private float health;
	[SerializeField] private float runAwayRange;
	//serialize float xpgiven

	public float Health { get => health; set => health = value; }
	public float MaxHealth { get => maxHealth; set => maxHealth = value; }
	public float RunAwayRange { get => runAwayRange; set => runAwayRange = value; }

	protected abstract void Move();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
