using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    [SerializeField]
    float walkSpeed = 5f;

    [SerializeField]
    public GameObject moveableCharacter;    

    Rigidbody2D playerRigidbody2D;

    Vector2 moveDirection;

    float horizontal;

    float vertical;

    bool playerMoving = false;

    Animator anim;


	// Use this for initialization
	void Start () 
	{
        

        if (moveableCharacter == null)
        {
            moveableCharacter = GameManager.Instance.spawnedPlayer;
        }
        playerRigidbody2D = moveableCharacter.GetComponent<Rigidbody2D>();
        anim = moveableCharacter.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        SetInputs();
        
        //Debug.Log(horizontal);
        //Debug.Log(vertical);
        Move();
	}

    void SetInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {

        playerRigidbody2D.velocity =
            new Vector2(horizontal, vertical) * walkSpeed * Time.deltaTime;

        if (playerRigidbody2D.velocity.magnitude > .1f)
        {
            playerMoving = true;
        }
        else
        {
            playerMoving = false;
        }

        anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxis("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        //anim.SetFloat("LastMoveX", movement.x);
        //anim.SetFloat("LastMoveY", movement.y);

    }

    private void UpdateRigidBody()
    {        
        playerRigidbody2D.velocity = Vector2.zero;
        playerRigidbody2D.isKinematic = true;
        playerRigidbody2D = moveableCharacter.GetComponent<Rigidbody2D>();
        anim = moveableCharacter.GetComponent<Animator>();

        if (playerRigidbody2D.isKinematic == true)       
            playerRigidbody2D.isKinematic = false;
        
    }

    private void OnEnable()
    {
        SpawnCreature.AvatarChanged += UpdateRigidBody;
    }

    private void OnDisable()
    {
        SpawnCreature.AvatarChanged -= UpdateRigidBody;
    }

}
