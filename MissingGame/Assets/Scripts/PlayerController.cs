using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    [SerializeField] 
    private float climbSpeed = 20f;

    [SerializeField] 
    private float jumpAmount = 10f;
    
    private float horizontalInput;
    private float verticalInput;
    
    private float horizontalMovement;
    private float verticalMovement;
    
    private Rigidbody2D rb;

    private Animator animator;
    
    private bool isGrounded = true;

    private bool jumpPressed;

    private bool canMove = true;
    
    private bool canClimb;

    private bool isClimbing;

    private float gravScale;
    
    [SerializeField] 
    private GameObject groundCheck;

    [SerializeField] 
    private LayerMask groundLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gravScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.02f, groundLayer);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (canClimb && Mathf.Abs(verticalInput) > 0f)
        {
            isClimbing = true;
            animator.SetBool("Climbing", true);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canMove)
        {
            jumpPressed = true;
        }
    }
    
    private void FixedUpdate()
    {
            horizontalMovement = horizontalInput * speed * Time.deltaTime;
            animator.SetFloat("Horizontal", horizontalMovement);
            animator.SetBool("Jumping", !isGrounded && !isClimbing);
            rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
        
            if (jumpPressed)
            {
                jumpPressed = false;
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            }

            if (isClimbing)
            {
                verticalMovement = verticalInput * climbSpeed * Time.deltaTime;
                animator.SetFloat("Vertical", verticalMovement);
                rb.gravityScale = 0.0f;
                rb.velocity = new Vector2(rb.velocity.x, verticalMovement);
            }
            else
            {
                rb.gravityScale = gravScale;
            }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Climbable"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Climbable"))
        {
            canClimb = false;
            isClimbing = false;
            animator.SetBool("Climbing", false);
        }
    }
}
