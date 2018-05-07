using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {

    [SerializeField]
    SpawnCreature spawnCreature;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    bool unlockCreature2;

    [SerializeField]
    bool unlockCreature3;

    [SerializeField]
    Text unlockText;

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
                unlockText.text = "Mini Skeleton Unlocked!";
                unlockText.gameObject.SetActive(true);
                spawnCreature.canSpawnCreature2 = true;
                StartCoroutine(UnlockTextFlash());
            }

            if (unlockCreature3)
            {
                unlockText.text = "Skeleton Mage Unlocked!";
                unlockText.gameObject.SetActive(true);
                spawnCreature.canSpawnCreature3 = true;
                StartCoroutine(UnlockTextFlash());
            }

        }
    }

    IEnumerator UnlockTextFlash()
    {
        yield return new WaitForSeconds(5f);
        unlockText.gameObject.SetActive(false);
    }
}
