using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    [SerializeField]
    float walkSpeed = 5f;

    [SerializeField]
    float runSpeed = 8f;

    Rigidbody2D playerRigidbody2D;

    Vector2 moveDirection;

    float horizontal;

    float vertical;


	// Use this for initialization
	void Start () 
	{
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () 
	{
        SetInputs();
        Debug.Log(horizontal);
        Debug.Log(vertical);
        Move();
	}

    void SetInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        //if (Input.GetAxis("Horizontal") > .5f || Input.GetAxis("Horizontal") > -.5f)
        //{
        //    moveDirection = horizontal;
        //    playerRigidbody2D.AddForce(moveDirection * walkSpeed);
        //}

        //if (Input.GetAxis("Vertical") > .5f || Input.GetAxis("Vertical") > -.5f)
        //{
        //    moveDirection = vertical;
        //    playerRigidbody2D.AddForce(moveDirection * walkSpeed);
        //}

        playerRigidbody2D.velocity =
            new Vector2(horizontal, vertical) * walkSpeed * Time.deltaTime;
    }

}
