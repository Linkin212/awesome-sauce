using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkrange : MonoBehaviour
{
    //this script is the part of the ai that detects if the player is in range of their attacks
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if the collision object was the player
        if (collision.CompareTag("Player"))
        {
            //says to the ai script that the player is in range
            GameObject enemy = GameObject.FindWithTag("Enemy");
            enemy.GetComponent<Enemy>().atkrange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //says to the ai script that the player is no longer in range
            GameObject enemy = GameObject.FindWithTag("Enemy");
            enemy.GetComponent<Enemy>().atkrange = false;
        }
    }
}
