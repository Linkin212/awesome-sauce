using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool wait = false;
    public float fallTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.5f;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wait = true;
        }
    }

    private void Update()
    {
        if (wait == true)
        {
            fallTime -= Time.deltaTime;
            if (fallTime <= 0)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                wait = false;

            }
        }
    }
}

