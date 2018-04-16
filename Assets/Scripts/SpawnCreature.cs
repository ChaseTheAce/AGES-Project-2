using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreature : MonoBehaviour 
{
    public static event Action AvatarChanged;

    [SerializeField]
    Creature creature1;

    [SerializeField]
    GameObject creature2;

    [SerializeField]
    GameObject creature3;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    Movement movement;

    [SerializeField]
    CameraController cameraController;

    

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (Input.GetButtonDown("Spawn"))
        {
            GameObject creature = Instantiate(creature2, spawnPoint) as GameObject;
            creature.transform.parent = null;
            movement.moveableCharacter = creature;
            cameraController.avatarToFollow = creature;

            if (AvatarChanged != null)
            {
                AvatarChanged.Invoke();
            }
        }
        
    }
}
