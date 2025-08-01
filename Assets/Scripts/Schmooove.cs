using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schmooove : MonoBehaviour
{
    private float groundCheckDistance = 0.1f;
    public float jumpPower = 5;
    public float speed = 5;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator an;

    private void Start()
    {
        
    }

    //I could explain my old code but i dont feel like it ask me if you want to change it :)
    private void Update()
    {
        GameObject Vaultcheck = GameObject.FindWithTag("Vaultcheck");
        float moveInput = Input.GetAxisRaw("Horizontal");
        // Left movement
        if (moveInput < 0)
        {
            rb.velocity = new UnityEngine.Vector2(moveInput * speed, rb.velocity.y);
            transform.localScale = new Vector3(-1, 2.1669f);
            an.SetBool("ismoving", true);
        }
        // Right movement
        if (moveInput > 0)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            transform.localScale = new Vector3(1, 2.1669f);
            an.SetBool("ismoving", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpPower);
        }

        if (moveInput == 0)
        {
            rb.velocity = new UnityEngine.Vector2(0, rb.velocity.y);
            an.SetBool("ismoving", false);
        }
    }
    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, UnityEngine.Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

}
