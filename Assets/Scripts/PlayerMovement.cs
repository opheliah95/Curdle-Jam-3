using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 movement, direction;
    public Rigidbody2D rb;

    public Animator animator;
    
    // TODO: Give up like a bitch and have a facing vector

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        direction = new Vector2(
            movement != Vector2.zero ? movement.x : animator.GetFloat("Horizontal"),
            movement != Vector2.zero ? movement.y : animator.GetFloat("Vertical")
            );

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        transform.localScale = new Vector2((animator.GetFloat("Horizontal") < 0? -1 : 1), 1);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
