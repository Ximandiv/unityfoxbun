using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public TrailRenderer tr;
    public ParticleSystem ps;

    public CapsuleCollider2D Collider;

    private float dirX;

    private bool isFacingRight = true;
    private bool canDash = true;
    public bool isDashing;
    public bool dashing = false;
    private bool doubleJump;
    public bool crouchingPressed;
    public bool isFull = false;
    public bool shortDash;

    public float dashingPower;
    public float movementSpeed;
    public float jumpingPower;
    public float twoJumpingPower;
    public float crouchPercentOfHeight = 0.5f;
    public bool isCrouching;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private Vector2 standColliderSize;
    private Vector2 standColliderOffset;
    private Vector2 crouchColliderSize;
    private Vector2 crouchColliderOffset;
    public static Action OnObjectDropped;

    private enum movementState
    {
        idle, running, jump, dash, crouch, falling
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ps.Stop();
        Collider = GetComponent<CapsuleCollider2D>();
        standColliderSize = Collider.size;
        standColliderOffset = Collider.offset;

        crouchColliderSize = new Vector2(standColliderSize.x, standColliderSize.y * crouchPercentOfHeight);
        crouchColliderOffset = new Vector2(standColliderOffset.x, standColliderOffset.y * crouchPercentOfHeight);
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        if (isDashing)
        {
            return;
        }
        dirX = Input.GetAxisRaw("Horizontal");
        Flip();

        if (IsGrounded() && !Input.GetButtonDown("Jump"))
        {
            doubleJump = true;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded()) {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                createParticle();
            }
            else if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, twoJumpingPower);
                doubleJump = !doubleJump;
                createParticle();
            }
        }

            animationupdate();

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            crouchingPressed = true;
            Crouch();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            crouchingPressed = false;
            StandingUp();
        }

        if (isDashing)
        {
            dashing = true;
        }
        else
        {
            dashing = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            isFull = false;
            OnObjectDropped();
        }
    }

    private void Crouch()
    {
        if (crouchingPressed)
        {
            isCrouching = true;
            Collider.size = crouchColliderSize;
            Collider.offset = crouchColliderOffset;
        }
    }

    private void StandingUp()
    {
        if (!crouchingPressed)
        {
            isCrouching = false;
            Collider.size = standColliderSize;
            Collider.offset = standColliderOffset;
        }
    }

    private void animationupdate()
    {
        movementState state;
        if (dirX > 0f)
        {
            state = movementState.running;
            if (crouchingPressed)
            {
                state = movementState.crouch;
            }
            else if(rb.velocity.y < -.9f)
            {
                state = movementState.falling;
            }
            else if (rb.velocity.y > .1f)
            {
                state = movementState.jump;
            }
        }
        else if (dirX < 0f)
        {
            state = movementState.running;
            Flip();
            if (crouchingPressed)
            {
                state = movementState.crouch;
            }
            else if (rb.velocity.y < -.9f)
            {
                state = movementState.falling;
            }
            else if (rb.velocity.y > .1f)
            {
                state = movementState.jump;
            }
        }
        else if (crouchingPressed)
        {
            state = movementState.crouch;
            if (rb.velocity.y < -.9f)
            {
                state = movementState.falling;
            }
            else if (rb.velocity.y > .1f)
            {
                state = movementState.jump;
            }
        }
        else if(Input.GetButtonDown("Jump"))
        {
            state = movementState.jump;
        }
        else
        {
            state = movementState.idle;
            if (rb.velocity.y < -.9f)
            {
                state = movementState.falling;
            }
            else if (rb.velocity.y > .1f)
            {
                state = movementState.jump;
            }
        }
        anim.SetInteger("state", (int)state);
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && dirX < 0f || !isFacingRight && dirX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        print("bruh");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Item" && Input.GetKeyDown(KeyCode.J))
        {
            Destroy(collision.gameObject);
        }
    }

    void createParticle()
    {
        ps.Play();
    }
 }
