using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schmooove : MonoBehaviour
{
    private float groundCheckDistance = 0.1f;
    private float moveInput = 0;
    public float jumpPower = 5;
    public float speed = 5;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
   
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        // Left movement
        if (moveInput < 0)
        {
            rb.velocity = new UnityEngine.Vector2(moveInput * speed, rb.velocity.y);
            transform.localScale = new Vector3(-1, 2.1669f);
            GameObject PlayerHB = GameObject.FindWithTag("PlayerHB");
            PlayerHB.transform.position = new Vector2(0.3171f * moveInput + rb.velocity.x, rb.velocity.y - 2.6502f);
        }
        // Right movement
        if (moveInput > 0)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            transform.localScale = new Vector3(1, 2.1669f);
            GameObject PlayerHB = GameObject.FindWithTag("PlayerHB");
            PlayerHB.transform.position = new Vector2(0.3171f * moveInput + rb.velocity.x, rb.velocity.y - 2.6502f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpPower);
        }

        if (moveInput == 0)
        {
            rb.velocity = new UnityEngine.Vector2(0, rb.velocity.y);
        }
    }
    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, UnityEngine.Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

}
