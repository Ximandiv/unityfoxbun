using System;
using System.Collections.Generic;
using UnityEngine;

public class rootbehavior : MonoBehaviour
{
    [SerializeField] private RootActivationMode activationMode;

    private Animator anim;
    public SpriteRenderer sprite;

    public static Action OnKilled;
    public static Action<Transform> OnPlatform;

    private bool IsRootActive => sprite.enabled;

    private enum movementState
    {
        idle, moving
    }

    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void Update()
    {
        if(anim != null) animationupdate();
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
        if (activationMode != RootActivationMode.onExit) return;

        if (collision.CompareTag("Player"))
        {
            Activate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (activationMode == RootActivationMode.immediately) Activate();

            if (collision.gameObject.GetComponent<PlayerController>().IsGrounded() == true) 
            {
                if (IsRootActive == true && activationMode != RootActivationMode.never)
                {
                    collision.gameObject.GetComponent<FoxGameplay>().Die();
                    OnKilled?.Invoke();
                }
                else
                {
                    OnPlatform?.Invoke(transform);
                }
            }
        }
    }

    private void Activate() 
    {
        sprite.enabled = true;
        anim.enabled = true;
    }
}

public enum RootActivationMode { never, onExit, immediately }