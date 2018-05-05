using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDart : MonoBehaviour {

    [SerializeField]
    Transform dartSpawnLocation;

    [SerializeField]
    Rigidbody2D dartPrefab;

    [SerializeField]
    float dartSpeed = 5f;

    [SerializeField]
    float spawnRate;


    public bool isActivated;

    bool canShoot = true;

    private void Update()
    {
        SpawnDart();
    }

    private void SpawnDart()
    {
        if (isActivated)
        {

            if (canShoot)
            {
                Rigidbody2D dartInstance = Instantiate(dartPrefab, dartSpawnLocation.position, (dartSpawnLocation.rotation)) as Rigidbody2D;
                dartInstance.velocity = dartSpeed * dartSpawnLocation.right;
                canShoot = false;
                StartCoroutine(SpawnDelay());
            }
        }
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnRate);
        canShoot = true;
        
    }

    


}
