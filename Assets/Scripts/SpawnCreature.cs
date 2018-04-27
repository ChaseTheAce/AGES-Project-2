using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreature : MonoBehaviour 
{
    public static event Action AvatarChanged;

    [SerializeField]
    GameObject player;

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

    GameObject creature;

    bool isPlayingCreature = false;

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (Input.GetButtonDown("Spawn") && (isPlayingCreature == false))
        {
            creature = Instantiate(creature2, spawnPoint) as GameObject;
            creature.transform.parent = null;
            movement.moveableCharacter = creature;
            cameraController.avatarToFollow = creature;
            isPlayingCreature = true;

            if (AvatarChanged != null)
            {
                AvatarChanged.Invoke();
            }
        }
        else if (Input.GetButtonDown("Spawn") && (isPlayingCreature == true))
        {
            movement.moveableCharacter = player;
            cameraController.avatarToFollow = player;
            isPlayingCreature = false;

            if (AvatarChanged != null)
            {
                AvatarChanged.Invoke();
            }

            Destroy(creature);
        }
        
    }
}
