using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    SpawnCreature spawnCreature;

    private void Start()
    {
        spawnCreature = GameManager.Instance.gameObject.GetComponent<SpawnCreature>();
    }

    public void Die()
    {
        spawnCreature.DespawnAll();
        gameObject.transform.position = Checkpoint.respawnPoint.position;
        
    }
}
