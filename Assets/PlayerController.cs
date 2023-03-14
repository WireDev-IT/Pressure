using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Animator animator;
    SpriteRenderer spriteRenderer;

    Vector2 movementInp;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {}

    private void FixedUpdate() {
        if (movementInp != Vector2.zero) {
            bool success = TryMove(movementInp);

            if (!success) {
                success = TryMove(new Vector2(movementInp.x, 0));
                if (!success) {
                    success = TryMove(new Vector2(0, movementInp.y));
                }
            }
        }
    }

    public bool TryMove(Vector2 direction) {
        int count = rb.Cast(direction, movementFilter, castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0) {
            rb.MovePosition(rb.position +
                    direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else {
            return false;
        }
    }

    void OnMove(InputValue movement) {
        movementInp = movement.Get<Vector2>();

        if (movementInp.x != 0 || movementInp.y != 0) {
            animator.SetFloat("X", movementInp.x);
            animator.SetFloat("Y", movementInp.y);
            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }

        if (movementInp.x < 0) {
            spriteRenderer.flipX = true;
        } else if (movementInp.x > 0) {
            spriteRenderer.flipX = false;
        }
    }
}
