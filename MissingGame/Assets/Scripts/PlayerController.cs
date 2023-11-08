using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    [SerializeField] private float jumpAmount = 10f;
    private float horizontalInput;
    private float horizontalMovement;
    private Rigidbody2D rb;

    private Animator animator;
    
    private bool isGrounded = true;

    private bool jumpPressed;
    
    [SerializeField] 
    private GameObject groundCheck;

    [SerializeField] 
    private LayerMask groundLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.02f, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpPressed = true;
        }
    }
    
    private void FixedUpdate()
    {
        horizontalMovement = horizontalInput * speed * Time.deltaTime;
        animator.SetFloat("Horizontal", horizontalMovement);
        animator.SetBool("Jumping", !isGrounded);
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
        
        if (jumpPressed)
        {
            jumpPressed = false;
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }
}
