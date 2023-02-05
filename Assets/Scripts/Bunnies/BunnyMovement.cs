using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour
{
    [SerializeField] private float timeBetweenJumps;
    [SerializeField] private float jumpForceY;
    [SerializeField] private float jumpForceX;

    private bool isJumping;
    private Animator animator;
    new private SpriteRenderer renderer;
    new private Rigidbody2D rigidbody;

    private void Awake()
    {
        isJumping = true;

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Invoke(nameof(StartJumping), UnityEngine.Random.Range(0f, 2f));
    }

    private void StartJumping() 
    {
        StartCoroutine(Jumping());
    }

    private void Jump() 
    {
        bool goToRight = UnityEngine.Random.Range(1, 3) % 2 == 0;
        renderer.flipX = !goToRight;
        rigidbody.AddForce(new Vector2(jumpForceX * (goToRight? 1 : -1), jumpForceY), ForceMode2D.Impulse);

        if(jumpForceX != 0) animator.SetTrigger("Jump");
    }

    IEnumerator Jumping()
    {
        while(isJumping == true) 
        {
            Jump();
            yield return new WaitForSeconds(timeBetweenJumps);
        }
    }
}
