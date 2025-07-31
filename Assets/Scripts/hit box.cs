using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public bool IsPlayerDead = false; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this is the codefor the hit boxes

        //if the collision is the player and they didnt parry they loose hp
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<powboompow>().parrywindow == false)
        {
            Debug.Log("Hit Player");
            collision.gameObject.GetComponent<powboompow>().Health -= 1;
            //once player hp reaches zero they die
            if (collision.gameObject.GetComponent<powboompow>().Health <= 0)
            {
                Debug.Log("Player is dead");
                IsPlayerDead = true;
            }
        }
    }
}
