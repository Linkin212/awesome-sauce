using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public bool trackplayer = false;

    // Update is called once per frame
    void Update()
    {
        if (trackplayer == true)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                transform.Translate(direction * Time.deltaTime);
            }
        }
    }
}
