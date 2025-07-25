using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public bool IsPlayerDead = false; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<powboompow>().parrywindow == false)
        {
            Debug.Log("Hit Player");
            collision.gameObject.GetComponent<powboompow>().Health -= 1;
            if (collision.gameObject.GetComponent<powboompow>().Health <= 0)
            {
                Debug.Log("Player is dead");
                IsPlayerDead = true;
            }
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            collision.gameObject.GetComponent<Enemy>().health -= 1;
        }
    }
}
