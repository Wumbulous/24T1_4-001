using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMovementSpeed = 1.0f;   // adjust movement speed
    public float mouseSens = 2.0f;      // adjust mouse sensitivity

    public float jumpHeight = 5.0f; // set player's jump height
    public bool isGrounded = false; // check if player is touching floor 

    public float vertRotation = 0;    //Adjust vertical rotation
    private Rigidbody rb;             // check character physics


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();         //Get Rigidbody of object

        Cursor.lockState = CursorLockMode.Locked;  //Lock cursor to game

    }

    // Update is called once per frame
    void Update()
    {
        WASD();

        RotationInput();

        Jump();   //Call jump function every frame

    }

    void RotationInput()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSens;
        
        transform.Rotate(0, horizontalRotation, 0);

        vertRotation -= Input.GetAxis("Mouse Y") * mouseSens;

        vertRotation = Mathf.Clamp(vertRotation, -90, 90);

        Camera.main.transform.localRotation = Quaternion.Euler(vertRotation, 0, 0);
    }

        void WASD()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * playerMovementSpeed;

        movement = transform.TransformDirection(movement);

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

    }
    void OnCollisionEnter(Collision collision) //first frame of player touching foor
    {
        if(collision.gameObject.CompareTag("Floor")) //check if player has made collision with the floor
        {
            isGrounded = true; //player is on ground
        }

        
    }
   void Jump() //allow player to jump
    {
       if(Input.GetKeyDown(KeyCode.Space) && isGrounded) //check if player presses space bar and is on the ground
        {
            isGrounded = false; //player is no longer on the ground

            rb.velocity = new Vector3(0, jumpHeight, 0); //move player on y to jumpheight

            
        }

    }
   
}    
