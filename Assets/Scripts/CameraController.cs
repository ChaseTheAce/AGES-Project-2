using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [SerializeField]
    public GameObject avatarToFollow;

    [SerializeField]
    Camera mainCamera;

    float cameraFollowSpeed = 5f;

    Transform playerTransform;
    private void Start()
    {
        playerTransform = avatarToFollow.GetComponent<Transform>();

        
    }

    private void Update()
    {
        Vector3 newPosistion = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newPosistion, cameraFollowSpeed * Time.deltaTime);
    }

    private void UpdatePlayerToFollow()
    {
        playerTransform = avatarToFollow.GetComponent<Transform>();
    }

    private void OnEnable()
    {
        SpawnCreature.AvatarChanged += UpdatePlayerToFollow;
    }

    private void OnDisable()
    {
        SpawnCreature.AvatarChanged -= UpdatePlayerToFollow;
    }
}
