using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"  || collision.tag == "Invulnerable" || collision.tag == "Creature2" || collision.tag == "Creature3")
        {
            // do something
        }
    }
}
