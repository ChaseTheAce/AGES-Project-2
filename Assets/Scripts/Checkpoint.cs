using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public static Transform respawnPoint;

    Transform startSpawn;

    private void Start()
    {
        startSpawn = GameManager.Instance.startingSpawn;
        respawnPoint = startSpawn;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            respawnPoint = gameObject.transform;
        }
    }
}
