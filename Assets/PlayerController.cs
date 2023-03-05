using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movementInp;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public float moveSpeed = 5f;
    public float collisionOffset = 0.005f;
    public ContactFilter2D movementFilter;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementInp != Vector2.zero)
        {
            bool success = TryMove(movementInp);
            if (!success)
            {
                success = TryMove(new Vector2(movementInp.x, 0));
                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInp.y));
                }
            }
        }
    }

    public bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
        );
        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInp = movementValue.Get<Vector2>();
    }
}
