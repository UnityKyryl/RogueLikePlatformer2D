using System.Collections;
using UnityEngine;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundObject;
        [SerializeField] private float checkRadius;
        [SerializeField] private int maxJumpCount;
    
        [SerializeField] private float dashDistance = 5f;
        [SerializeField] private float dashDelay = 1f;

        private Rigidbody2D rb;
        private Animator anim;
        private bool facingRight = true;
        private bool isJumping = true;
        private float moveDirection;
        private bool isGrounded;
        private int jumpCount;
        private static readonly int AnimParam = Animator.StringToHash("AnimParam");
    
        private bool isDashing;
        private float gravity;
        private bool canDash = true;
        #endregion

        #region Methods

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            gravity = rb.gravityScale;
        }

        private void Start()
        {
            jumpCount = maxJumpCount;
        }

        private void Update()
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
            if(!isDashing)
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
            anim.SetInteger(AnimParam, moveDirection == 0 ? 0 : 1);
            if (moveDirection > 0 && !facingRight)
                FlipCharacter();
            else if (moveDirection < 0 && facingRight)
                FlipCharacter();
        }

        private void ProcessInput()
        {
            moveDirection = Input.GetAxis("Horizontal");
        
            if (Input.GetKeyDown("left shift") && canDash)
            {
                StartCoroutine(Dash());
            }

            if (!Input.GetButtonDown("Jump") || jumpCount <= 0) return;
            isJumping = true;
        }

        private void FlipCharacter()
        {
            facingRight = !facingRight;
            transform.Rotate(0f,180f,0f);
        }

        private IEnumerator Dash()
        {
            isDashing = true;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(facingRight ? new Vector2(dashDistance, 0f) : new Vector2(-dashDistance, 0f), ForceMode2D.Impulse);
            rb.gravityScale = 0;
            yield return new WaitForSeconds(0.4f);
            isDashing = false;
            rb.gravityScale = gravity;
            canDash = false;
            StartCoroutine(DashDelay());
        }

        private IEnumerator DashDelay()
        {
            yield return new WaitForSeconds(dashDelay);
            canDash = true;
        }

        #endregion
    }
}
