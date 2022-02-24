using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using TMPro; 

public class PlayerController : MonoBehaviour
{ 
    // Create public variables for player speed, and for the Text UI game objects
    public float speed = 0;
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
       count = 0; 

       SetCountText (); 
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }
  
    void SetCountText()
    {
		countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true); 
        }
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
            count = count + 1;

            // Run the 'SetCountText()' function
    
            SetCountText(); 
       } 
    }
}  