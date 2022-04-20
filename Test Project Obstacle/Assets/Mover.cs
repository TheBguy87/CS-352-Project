using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump;
    [SerializeField] float jumpForce = 9;
    float moveSpeed = 10f;
    bool isGrounded;
    int pad;
    public float globalGravity = -7f;
    [SerializeField] public float gravityScale = 4;
    [SerializeField] public float fallingGravityScale = 15;

    [SerializeField] public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        isGrounded = true;
    }

    void OnCollisionStay() {
        isGrounded = true;
    }


    void Update() {

        if(pad>0){pad--;  isGrounded = false;}
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if(pad == 0) {
                pad = 5;
                isJumping = true;
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        if(isJumping == true) {
            isGrounded = false;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse); 
            isJumping = false;    
        }
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

