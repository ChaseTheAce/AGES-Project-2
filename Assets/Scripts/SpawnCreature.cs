using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    GameObject helpPanel;

    [SerializeField]
    Text creatureSelectText;

    [SerializeField]
    Text creature2Text;

    [SerializeField]
    Text creature3Text;

    public bool canSpawnCreature2;

    public bool canSpawnCreature3;

    //public static bool isPlayingCreature3 = false;

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
        ToggleHelp();
    }

    private void SelectCreature()
    {

        if (Input.GetButtonDown("Select1"))
        {
            selectedCreature = creature1;
            ControlSelectedCreature();
            creatureSelectText.text = ("Selected Spawn: Skeleton Knight");
            //isPlayingCreature3 = false;
        }
        if (Input.GetButtonDown("Select2") && canSpawnCreature2)
        {
            if (canSpawnCreature2)
            {
                selectedCreature = creature2;
                ControlSelectedCreature();
                creatureSelectText.text = ("Selected Spawn: Mini Skeleton");
                //isPlayingCreature3 = false;
            }
            else if (!canSpawnCreature2)
            {
                creatureSelectText.text = ("Mini Skeleton Locked!");
            }

        }
        if (Input.GetButtonDown("Select3") && canSpawnCreature3)
        {
            if (canSpawnCreature3)
            {
                selectedCreature = creature3;
                ControlSelectedCreature();
                creatureSelectText.text = ("Selected Spawn: Skeleton Mage");
            }
            else if (!canSpawnCreature3)
            {
                creatureSelectText.text = ("Skeleton Mage Locked!");
            }


            //if (spawnedCreatures.Contains(creature3))
            //{
            //    isPlayingCreature3 = true;
            //}

        }
    }

    void SetHelpText()
    {
        if (!canSpawnCreature2)
        {
            creature2Text.text = "2: Mini Skeleton Locked!";
        }
        if (canSpawnCreature2)
        {
            creature2Text.text = "2: Mini Skeleton";
        }
        if (!canSpawnCreature3)
        {
            creature3Text.text = "3: Skeleton Mage Locked!";
        }
        if (canSpawnCreature3)
        {
            creature3Text.text = "3: Skeleton Mage";
        }
    }

    void ToggleHelp()
    {
        if(Input.GetButtonDown("Help"))
        {
            SetHelpText();
            if (!helpPanel.activeSelf)
            {
                helpPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else if (helpPanel.activeSelf)
            {
                helpPanel.SetActive(false);
                Time.timeScale = 1;
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

    public void DespawnAll()
    {
        List<GameObject> tempList = new List<GameObject>();

        foreach (GameObject creature in spawnedCreatures)
        {
            if (creature != null)
                tempList.Add(creature);
        }

        foreach (GameObject creature in tempList)
        {            
                spawnedCreatures.Remove(creature);
                Destroy(creature.gameObject);
            
        }
    }
}
