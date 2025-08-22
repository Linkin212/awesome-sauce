using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathbox : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player enters the deathbox they die
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is dead");
            collision.gameObject.GetComponent<powboompow>().Health = 0;
        }
    }
}
