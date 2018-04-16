using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour 
{
    int health;

    int speed;

    Rigidbody2D creatureRigidBody;

	// Use this for initialization
	void Start () 
	{
        creatureRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
