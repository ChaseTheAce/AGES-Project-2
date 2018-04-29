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
