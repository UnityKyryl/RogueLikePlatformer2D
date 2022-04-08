using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundObject;
    [SerializeField] private float checkRadius;
    [SerializeField] private int maxJumpCount;

    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;
    private bool isJumping = true;
    private float moveDirection;
    private bool isGrounded;
    private int jumpCount;
    private static readonly int AnimParam = Animator.StringToHash("AnimParam");

    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        jumpCount = maxJumpCount;
    }

    void Update()
    {
        ProcessInput();

        Animate();
        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);

        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            jumpCount--;
        }
        
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
            FlipCharacter();
        else if (moveDirection < 0 && facingRight)
            FlipCharacter();
    }

    private void ProcessInput()
    {
        moveDirection = Input.GetAxis("Horizontal");
        
        anim.SetInteger(AnimParam, moveDirection == 0 ? 0 : 1);
        
        if (!Input.GetButtonDown("Jump") || jumpCount <= 0) return;
        isJumping = true;
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
}
