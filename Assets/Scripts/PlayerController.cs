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
    public static Action OnObjectPicked;

    private float dirX;

    private bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing;
    private bool doubleJump;

    public float dashingPower;
    public float movementSpeed;
    public float jumpingPower;
    public float twoJumpingPower;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private enum movementState
    {
        idle, running, jump, attack
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        dirX = Input.GetAxisRaw("Horizontal");
        Flip();

        if(IsGrounded() && !GetJumpingInput())
        {
            doubleJump = true;
        }
        if (GetJumpingInput())
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

        //animationupdate();

        if (GetJumpingInput() && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    //private void animationupdate()
    //{
    //    movementState state;
    //    if (dirX > 0f)
    //    {
    //        state = movementState.running;
    //    }
    //    else if (dirX < 0f)
    //   {
    //        state = movementState.running;
    //        Flip();
    //    }
    //    else
    //    {
    //        state = movementState.idle;
    //    }
    //    if (rb.velocity.y > .1f)
    //    {
    //        state = movementState.jump;
    //    }
    //    else
    //    {
    //        state = movementState.idle;
    //    }
    //    anim.SetInteger("state", (int)state);
    //}

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
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool GetJumpingInput() 
    {
        return Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        //tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        //tr.emitting = false;
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
        if(collider.tag == "Steal" && isDashing)
        {
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Item" && Input.GetKeyDown(KeyCode.J))
        {
            OnObjectPicked();
            Destroy(collision.gameObject);
        }
    }

    void createParticle()
    {
        return;
        ps.Play();
    }
 }
