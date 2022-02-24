using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb; 

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    private void Update()
    {
      //when the jump buttonis pressed
      if( Input.GetButtonDown("Jump") )
        
      //(todo/should do: check to see if the player is on the ground)
      //add an upward force to the player 
      rb.AddForce(new Vector3(0f,300f,0f));  

    }


    void FixedUpdate() 
    {
        // Set some local float variables equal to the value of our Horizontal and Vertical Inputs 
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Verical"); 

        Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical); 

        Vector3 movement = new Vector3( movementX, 0.0f, movementY); 
        rb.AddForce(movement * speed); 

    }







}
