using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count; 

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
       rb = GetComponent<Rigidbody>(); 

       // Set the count to zero
       count = 0; 
       SetCountText (); 
       // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank 
       winTextObject.SetActive(false); 
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }


    void FixedUpdate() 
    {

        Vector3 movement = new Vector3 (movementX, 0.0f, movementY); 


        rb.AddForce(movement * speed); 

    }

    private void OnTriggerEnter(Collider other)
    {
        //..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
       if (other.gameObject.CompareTag("PickUp"))
       {
           other.gameObject.SetActive(false);
            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function
            SetCountText(); 
       } 

          void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }

        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
	}






}
