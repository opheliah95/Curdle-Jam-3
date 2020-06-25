using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 movement;
    public Rigidbody2D rb;

    public Animator animator;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", (movement != Vector2.zero ? movement.x : animator.GetFloat("Horizontal")));
        animator.SetFloat("Vertical", (movement != Vector2.zero ? movement.y : animator.GetFloat("Vertical")));
        animator.SetFloat("Speed", movement.sqrMagnitude);

        transform.localScale = new Vector2((animator.GetFloat("Horizontal") < 0? -1 : 1), 1);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
