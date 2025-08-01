using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Vault : MonoBehaviour
{
    public bool isHanging = false;
    public Rigidbody2D rb;
    public bool CD = false;
    public float CDtimer = 2;
    public bool nearwall = false;
    public bool climb = false;
    public int launch = 8;
    public Animator an;

    public void Update()
    {
        // This script allows the player to vault over walls when they are near them
        // The player must be above the wall to climb it
        // The player can only vault once every 2 seconds

        // Cooldown timer for vaulting
        if (CD == true)
        {
            CDtimer -= Time.deltaTime;
        }
        //resets the timer once it hits zero
       if (CDtimer <= 0)
        {
            CD = false;
            CDtimer = 2;
        }
        //if the player is next to a wall and can climb and the cool down is over they stick
        // to the wall and can vault by pressing space
        if (nearwall == true && climb == true && CD == false)
        {
            isHanging = true;
            an.SetBool("ishanging", true);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isHanging == true)
        {
            //launches the player up and starts the cooldown
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 1f;
            rb.AddForce(Vector2.up * launch, ForceMode2D.Impulse);
            isHanging = false;
            CD = true;
            an.SetBool("ishanging", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when the player walks away from the wall it turns off the ability to climb
        nearwall = false;
        climb = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //says the player is near a wall and checks for the layer of the object
        nearwall = true;
        if (collision.gameObject.layer == LayerMask.NameToLayer("floor"))
        {
            //this grabs the walls y position and the players y position and compares them
            //if the players y position is higher then it allows for climbing if not climbing doesnt happen
            float yfloor = collision.transform.position.y;
            GameObject player = GameObject.FindWithTag("Player");
            float yplayer = player.transform.position.y;
            if (yplayer > yfloor)
            {
                climb = true;
            }
        }
    }
}



