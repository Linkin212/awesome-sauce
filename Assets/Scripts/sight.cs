using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight : MonoBehaviour
{
    //this script is used to detect the player and make the enemy track them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if the gameobject is the player
        if (collision.gameObject.tag == ("Player"))
        {
            //activates tracking
            GameObject enemy = GameObject.FindWithTag("Enemy");
            enemy.GetComponent<Enemy>().trackplayer = true;
        }
    }


}
