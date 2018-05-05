using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    [SerializeField]
    SpawnCreature spawnCreature;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    bool unlockCreature2;

    [SerializeField]
    bool unlockCreature3;

    BoxCollider2D boxCollider2D;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

        boxCollider2D = GetComponent<BoxCollider2D>();
	}
	


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            if (unlockCreature2)
            {
                spawnCreature.canSpawnCreature2 = true;
            }

            if (unlockCreature3)
            {
                spawnCreature.canSpawnCreature3 = true;
            }

        }
    }
}
