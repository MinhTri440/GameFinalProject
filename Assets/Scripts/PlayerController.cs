using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;  // Lực nhảy
    public float moveSpeed = 5f;  // Tốc độ di chuyển ngang
    private Animator animator;
    private float moveDirection = 0f;
    private SpriteRenderer Sprite;




    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>(); 
        Sprite= GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
       
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationUpdate();

    }
    private void UpdateAnimationUpdate()
    {
        if (moveDirection > 0f)
        {
            animator.SetBool("Running", true);
            Sprite.flipX = false;
        }
        else if (moveDirection < 0f)
        {
            animator.SetBool("Running", true);
            Sprite.flipX = true;
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

}
