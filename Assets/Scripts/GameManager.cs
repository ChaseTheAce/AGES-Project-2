using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Transform startingSpawn;

    [SerializeField]
    GameObject playerPrefab;

    public GameObject spawnedPlayer;

    public static bool hasEnteredDoor = false;

    private const string saveFileName = "saveData.dat";

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        
    }



    public static void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveFileName);

        SaveData saveData = new SaveData();

        Debug.Log(Door.PlayerLocationY);
        saveData.playerXPos = Door.PlayerLocationX;
        saveData.playerYPos = Door.PlayerLocationY;

        binaryFormatter.Serialize(file, saveData);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + saveFileName))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveFileName, FileMode.Open);
            SaveData saveData = (SaveData)binaryFormatter.Deserialize(file);
            file.Close();

            GameObject player1 = Instance.spawnedPlayer;
            Debug.Log(saveData.playerYPos);
            MoveCharacter(player1, saveData.playerXPos, saveData.playerYPos);
        }
    }

    public static Vector2 SaveObjectLocation(GameObject objectToSave)
    {
        return objectToSave.transform.position;
    }

    public static void MoveCharacter(GameObject characterToMove, float locationX, float locationY)
    {
        if (characterToMove != null)
        {
            if (characterToMove != Door.characterToEnter)
                characterToMove.transform.position = new Vector2(locationX, locationY);

        }
        
    }

    public void SpawnPlayer()
    {
        spawnedPlayer = Instantiate(playerPrefab, startingSpawn) as GameObject;
        spawnedPlayer.transform.position = startingSpawn.position;
        spawnedPlayer.transform.parent = null;
    }
}

[Serializable]
public class SaveData
{
    public float playerXPos;
    public float playerYPos;

    public float creature1XPos;
    public float creature1YPos;

    public float creature2pos;
    public float creature2Pos;

}
