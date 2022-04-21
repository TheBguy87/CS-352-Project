/* CS 352 Project: Rise Up
 * Mover.cs
 * 
 * Brian Langejans And Chris Jeong
 * Date: 4/15/2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump;

    public float rotationSpeed;
    [SerializeField] float jumpForce = 9;
    float moveSpeed = 10f;
    bool isGrounded;
    int pad;
    public float globalGravity = -7f;
    [SerializeField] public float gravityScale = 4;
    [SerializeField] public float fallingGravityScale = 15;
    [SerializeField] public bool isJumping = false;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    void OnCollisionStay() {
        isGrounded = true;
    }


    void Update() {
        // get user input
        if(pad>0){pad--;  isGrounded = false;}
        float inputHoriz = Input.GetAxis("Horizontal");
        float inputVert = Input.GetAxis("Vertical");

        // move the user depending on direction
        Vector3 movementDirection = new Vector3(inputHoriz, 0, inputVert);
        movementDirection.Normalize();
        var translation = (movementDirection * Time.deltaTime * moveSpeed);
        transform.Translate(translation, Space.World);
        

        // handle looking in different directions
        // help from: https://www.youtube.com/watch?v=BJzYGsMcy8Q&t=431s
        if (movementDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // check for jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // pad helps keep character from jumping twice
            if(pad == 0) {
                pad = 5;
                isJumping = true;
            }
        }
        var plswork= (inputHoriz + inputVert);
        animator.SetBool("isMoving", plswork != 0);
    }

// fixed update that updates jumping physics
// help from: https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/#:~:text=The%20basic%20method%20of%20jumping,using%20the%20Add%20Force%20method.
    void FixedUpdate()
    {
        // create the force vector and apply it if the space bar is pressed
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        if(isJumping == true) {
            isGrounded = false;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse); 
            isJumping = false;    
        }
        // change force depending on regular gravity or extra falling gravity
        if(rb.velocity.y >= 0)
        {
            gravity = globalGravity * gravityScale * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
        else if (rb.velocity.y < 0)
        {
            gravity = globalGravity * fallingGravityScale * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);
        }


    }

}

