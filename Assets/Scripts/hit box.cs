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
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<powboompow>().parrywindow == false && collision.gameObject.GetComponent<powboompow>().Hit == false)
        {
            Debug.Log("Hit Player");
            collision.gameObject.GetComponent<powboompow>().Health -= 1;
            collision.gameObject.GetComponent<powboompow>().Hit = true;
            //once player hp reaches zero they die
            if (collision.gameObject.GetComponent<powboompow>().Health <= 0)
            {
                Debug.Log("Player is dead");
                IsPlayerDead = true;
            }
        }
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<powboompow>().parrywindow == true)
        {
            Debug.Log("Parried");
            //if the player parries the enemy they get their parry back
            collision.gameObject.GetComponent<powboompow>().parrycdactive = false;
            collision.gameObject.GetComponent<powboompow>().parrycd = 3f;
            //and the enemy is stunned for a short time
            GameObject enemy = GameObject.FindWithTag("Enemy");
            enemy.GetComponent<Enemy>().atkgoing = true;
            enemy.GetComponent<Enemy>().atktime = true;
        }
    }
}
