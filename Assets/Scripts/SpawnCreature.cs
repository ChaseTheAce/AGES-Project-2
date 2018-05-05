using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreature : MonoBehaviour
{
    public static event Action AvatarChanged;
    
    #region Serialized Fields
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject creature1;

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
    #endregion

    GameObject selectedCreature;

    GameObject creature;

    public static bool isPlayingCreature3 = false;

    bool isPlayingCreature = false;

    List<GameObject> spawnedCreatures;

    private void Start()
    {
        spawnedCreatures = new List<GameObject>();
        selectedCreature = creature1;

        if (player == null)
        {
            player = GameManager.Instance.spawnedPlayer;
            spawnPoint = GameObject.Find("CreatureSpawn").transform;
        }
    }

    private void Update()
    {
        SelectCreature();
        Switch();
        Spawn();
    }

    private void SelectCreature()
    {

        if (Input.GetButtonDown("Select1"))
        {
            selectedCreature = creature1;
            ControlSelectedCreature();
            isPlayingCreature3 = false;
        }
        if (Input.GetButtonDown("Select2"))
        {
            selectedCreature = creature2;
            ControlSelectedCreature();
            isPlayingCreature3 = false;
        }
        if (Input.GetButtonDown("Select3"))
        {
            selectedCreature = creature3;
            ControlSelectedCreature();

            if (spawnedCreatures.Contains(creature3))
            {
                isPlayingCreature3 = true;
            }
            
        }
    }

    private void ControlSelectedCreature()
    {
        foreach (GameObject creature in spawnedCreatures)
        {
            if (creature.tag == selectedCreature.tag)
            {
                movement.moveableCharacter = creature;
                cameraController.avatarToFollow = creature;
                isPlayingCreature = true;

                if (AvatarChanged != null)
                {
                    AvatarChanged.Invoke();
                }
            }

        }
    }

    #region Button Fucntions
    public void SelectCreature1BtnPressed()
    {
        selectedCreature = creature1;
    }

    public void SelectCreature2BtnPressed()
    {
        selectedCreature = creature2;
    }

    public void SelectCreature3BtnPressed()
    {
        selectedCreature = creature3;
    }
    #endregion

    private void Switch()
    {
        if (player == null)
        {
            player = GameManager.Instance.spawnedPlayer;
            spawnPoint = GameObject.Find("CreatureSpawn").transform;
        }

        // Switches back to main character if the user is controlling a creature 
        if (Input.GetButtonDown("Switch") && (isPlayingCreature == true))
        {
            movement.moveableCharacter = player;
            cameraController.avatarToFollow = player;
            isPlayingCreature = false;

            if (AvatarChanged != null)
            {
                AvatarChanged.Invoke();
            }

        }
    }

    private void Spawn()
    {
        if (player == null)
        {
            player = GameManager.Instance.spawnedPlayer;
            spawnPoint = GameObject.Find("CreatureSpawn").transform;
        }

        // Spawns a creature if the user is not currently controlling a creature
        if (Input.GetButtonDown("Spawn") && (isPlayingCreature == false))
        {
            if (creature != null)
            {
                List<GameObject> tempList = new List<GameObject>();

                foreach (GameObject creature in spawnedCreatures)
                {
                    if (creature != null)
                        tempList.Add(creature);                   
                }

                foreach (GameObject creature in tempList)
                {
                    if (creature.tag == selectedCreature.tag)
                    {
                        spawnedCreatures.Remove(creature);
                        Destroy(creature.gameObject);
                    }
                }
                
            }
            creature = Instantiate(selectedCreature, spawnPoint) as GameObject;
            creature.transform.parent = null;
            movement.moveableCharacter = creature;
            cameraController.avatarToFollow = creature;
            isPlayingCreature = true;
            spawnedCreatures.Add(creature);

            if (AvatarChanged != null)
            {
                AvatarChanged.Invoke();
            }
        }
        // Destroys the currently controlled creature and swtiches back to main character
        else if (Input.GetButtonDown("Despawn") && (isPlayingCreature == true))
        {
            Despawn(creature);
        }
        
    }

    public void Despawn(GameObject creatureToDespawn)
    {
        {
            movement.moveableCharacter = player;
            cameraController.avatarToFollow = player;
            isPlayingCreature = false;

            if (AvatarChanged != null)
            {
                AvatarChanged.Invoke();
            }

            spawnedCreatures.Remove(creatureToDespawn);
            Destroy(creatureToDespawn);
        }
    }
}
