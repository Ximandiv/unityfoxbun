using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public SpriteRenderer rend;
    public GameObject place;
    public PlayerController PlayerController;
    public Rigidbody2D rb;
    public bool isFacingRight;

    private Animator anim;

    private enum movementState
    {
        idle, run
    }
    private void Flip()
    {
        if (isFacingRight && rb.velocity.x < 0f || !isFacingRight && rb.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Update()
    {
        //animationupdate();
        Flip();
    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if (rend != null) rend.enabled = true;
            else place.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (rend != null) rend.enabled = false;
            else place.gameObject.SetActive(false);
        }
    }
    private void animationupdate()
    {
        movementState state2;
        if(rb.velocity.x > 0f)
        {
            state2 = movementState.run;
        }
        else if(rb.velocity.x < 0f)
        {
            state2 = movementState.run;
        }
        else
        {
            state2 = movementState.idle;
        }
        anim.SetInteger("state2", (int)state2);
    }
}
