using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foxguide : MonoBehaviour
{
    private Animator anim;
    public SpriteRenderer dialogue;
    public bool inRange = false;
    private enum movementState
    {
        idle, idle2
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
        movementState state3;
        if (inRange)
        {
            state3 = movementState.idle2;
        }
        else
        {
            state3 = movementState.idle;
        }
        anim.SetInteger("state3", (int)state3);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            inRange = true;
            dialogue.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        dialogue.enabled = false;
    }
}
