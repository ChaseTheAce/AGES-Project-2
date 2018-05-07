using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    [SerializeField]
    GameObject pairedTeleporter;

    private static bool hasTeleported = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Creature3" && hasTeleported == false)
        {
            collision.transform.position = pairedTeleporter.transform.position;
            hasTeleported = true;
            StartCoroutine(TeleporterReset());
            
        }
    }

    IEnumerator TeleporterReset()
    {
        yield return new WaitForSeconds(.5f);
        hasTeleported = false;
    }

    
    


}
