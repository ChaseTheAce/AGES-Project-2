using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    // I was trying to load a new scene and save the positions of all characters who didn't go through the door but it was giving me a lot of trouble so I didnt acutally use this along with the save/load in game manager

    [SerializeField]
    Object sceneToLoad;

    [SerializeField]
    GameObject player;

    [SerializeField]
    bool isSaveOnUse = true;

    public static bool isInside = false;

    string sceneName;

    public static GameObject characterToEnter;

    private static float playerLocationX;
    public static float PlayerLocationX
    {
        get { return playerLocationX; }

        set
        {
            playerLocationX = value;
            GameManager.Save();
        }
    }

    private static float playerLocationY;
    public static float PlayerLocationY
    {
        get { return playerLocationY; }

        set
        {
            playerLocationY = value;
            GameManager.Save();
        }
    }

    // Use this for initialization
    void Start () {
        sceneName = sceneToLoad.name;
        player = GameManager.Instance.spawnedPlayer;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.hasEnteredDoor = true;
        characterToEnter = collision.gameObject;
        DontDestroyOnLoad(characterToEnter);
        if (isSaveOnUse)
            RecordPlayerPos(GameManager.SaveObjectLocation(player));

        isInside = true;
        SceneManager.LoadScene(sceneName);
        
    }

    private void RecordPlayerPos(Vector2 playerPos)
    {
        PlayerLocationX = playerPos.x;
        PlayerLocationY = playerPos.y;
    }

}
