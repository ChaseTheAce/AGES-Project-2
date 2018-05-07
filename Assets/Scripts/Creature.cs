using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Player
{
    GameObject gameManager;

    SpawnCreature spawnCreature;

    Rigidbody2D creatureRigidBody;

    public PressurePlate pressurePlate;

	// Use this for initialization
	void Start () 
	{

        gameManager = GameObject.Find("Game Manager");
        spawnCreature = gameManager.GetComponent<SpawnCreature>();
        creatureRigidBody = GetComponent<Rigidbody2D>();
	}
	
    public void Die()
    {
        if (pressurePlate != null)
        {
            pressurePlate.DeactivatePlate();
        }

        StartCoroutine(Wait());
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.1f);
        spawnCreature.Despawn(this.gameObject);
    }
}
