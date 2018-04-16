using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreature : MonoBehaviour 
{
    [SerializeField]
    Creature creature1;

    [SerializeField]
    GameObject creature2;

    [SerializeField]
    GameObject creature3;

    [SerializeField]
    Transform spawnPoint;

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (Input.GetButtonDown("Spawn"))
        {
            Creature creature = Instantiate(creature1, spawnPoint) as Creature;
            creature.transform.parent = null;
        }
        
    }
}
