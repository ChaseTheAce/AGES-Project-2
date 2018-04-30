using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Invulnerable")
        {
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            Player player = collision.collider.GetComponent<Player>();
            player.Die();
        }
        else if (collision.collider.tag == "Creature2" || collision.collider.tag == "Creature3")
        {
            Destroy(gameObject);
            Creature creature = collision.collider.GetComponent<Creature>();
            creature.Die();
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Map")
        {
            Destroy(gameObject);
        }
    }

}
