using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Player
{
    GameObject gameManager;

    SpawnCreature spawnCreature;

    Rigidbody2D creatureRigidBody;

	// Use this for initialization
	void Start () 
	{
        gameManager = GameObject.Find("Game Manager");
        spawnCreature = gameManager.GetComponent<SpawnCreature>();
        creatureRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    public void Die()
    {
        spawnCreature.Despawn(this.gameObject);
    }
}
