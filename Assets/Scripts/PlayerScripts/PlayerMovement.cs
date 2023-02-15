using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Used https://www.youtube.com/watch?v=K1xZ-rycYY8 for help

    //Need 4 Private Variables for Movement
    private float horizontal;//for horizontal input
    [SerializeField] private float speed = 8f;//for speed
    [SerializeField] private float jumpingPower = 16f;//for jumping power
    private bool isFacingRight = true;//Find out the direction player is facing

    //3 Seralized Fields to reference Rigid body, ground check and ground layer
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private LayerMask groundLayer;


    
    void Update()// Executed Every Frame
    {
        horizontal = Input.GetAxisRaw("Horizontal");//Returns a value of -1, 0, or +1 depending on the direction the player moves

        if(Input.GetButtonDown("Jump") && IsGrounded())//If jump button is pressed while grounded
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);//Set the the y of rigidbody's velocity to the jumpPower value
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)//If player lets go of jump button while player character is still jumping
                                                           //Essentially holding down the Jump button longer
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);//Multiples the velocity of the rigidbody y-axis by 0.5 for a "higher jump"
        }

        //FlipPlayer();//Executes FlipPlayer Method
    }

    private void FixedUpdate()//Executed each specified rate
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        //sets the value of the velocity of the rigid body to be the horizontal input multiplied by speed value
        //Velocity of RigidBody = Horizontal input (-1, 0, +1) x speed
        //Velocity is setting cords which is why "rb.velocity.y" remains the same, as its the y-axis (vertical)
    }

    private bool IsGrounded()//Checks if player is grounded, ready to jump
    {
        return Physics2D.OverlapBox(transform.position - new Vector3(0,0.5f), new Vector2(0.95f,1), 0f, groundLayer);
        //Vector2 is X,Y
        //Vector3 is X,Y,Z
        //Uses 3 parameters
        //1. Position of groundCheck
        //2. Small Radius of 0.2
        //3. Ground Layer
        //Purpose is to create a small circle at the bottom of the player object so when it collides with the ground layer, we're allowed to jump.
    }

    private void FlipPlayer()//Used to check if the player sprite need to be flipped
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        // Facing right and HORIZONTAL input is LESS than zero or
        // Facing left and HORIZONTAL input is MORE than zero
        // Left     Middle      Right
        //  -1        0          +1
        {
            isFacingRight = !isFacingRight;//to flip the player, set the value to the opposite value since we established at the start that the player is looking right
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;//Multiply the player's scale by -1 to flip it horizontally.
            transform.localScale = localScale;
        }


    }

}
