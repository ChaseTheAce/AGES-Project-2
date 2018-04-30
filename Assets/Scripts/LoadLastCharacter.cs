using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLastCharacter : MonoBehaviour {

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject defaultCharacter;


    GameObject characterToMove;

	// Use this for initialization
	void Awake () {
        if (GameManager.hasEnteredDoor)
        {


            if (Door.characterToEnter != null)
            {
                characterToMove = Door.characterToEnter;
            }
            else
            {
                characterToMove = defaultCharacter;
            }
            MoveCharacter();

        }
	}
	

    private void MoveCharacter()
    {       
        characterToMove.transform.position = spawnPoint.position;
    }
}
