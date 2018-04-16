using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [SerializeField]
    GameObject playerToFollow;

    Transform playerTransform;
    private void Start()
    {
        playerTransform = playerToFollow.GetComponent<Transform>();

        
    }

    private void Update()
    {
        this.gameObject.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
    }
}
