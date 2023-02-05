using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootbehavior : MonoBehaviour
{
    private Animator anim;
    public SpriteRenderer sprite;
    public bool inRange = false;
    public bool ending = false;
    private enum movementState
    {
        idle, moving
    }
    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        animationupdate();
    }
    private void animationupdate()
    {
        movementState state4;
        if (sprite.enabled == true)
        {
            state4 = movementState.moving;

        }
        else
        {
            state4 = movementState.idle;
        }
        anim.SetInteger("state4", (int)state4);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.enabled = true;
    }
}
