using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour 
{
    [SerializeField]
    Transform ExitTransform;

    GameObject characterToEnter;

    bool hasEntered = false;

	// Use this for initialization
	void Start () 
	{
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasEntered == false)
        {
            characterToEnter = collision.gameObject;            
            characterToEnter.transform.position = ExitTransform.position;
            Camera camera = GameManager.Instance.gameObject.GetComponentInChildren<Camera>();
            camera.transform.position = ExitTransform.position;
            hasEntered = true;
            StartCoroutine(DoorReset());
        }
        
    }

    IEnumerator DoorReset()
    {
        yield return new WaitForSeconds(.5f);
        hasEntered = false;
    }
}
