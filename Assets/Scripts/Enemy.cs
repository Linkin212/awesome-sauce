using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public bool trackplayer = false;
    public int speed = 4;
    public bool atkrange = false;
    public bool hit = false;
    public float timer = 0.5f;
    private float attackcooldown;
    private float attacktimer;
    public bool parry = false;
    public SpriteRenderer sr;
    public bool atimer = false;
    public GameObject circle;
    public bool atktime = false; 
    public float atklength = 0.5f;
    public bool atktimerstart = false;
    public bool atkgoing = false;

    private void Start()
    {
        setrandomcooldown();
    }
    void Update()
    {
        //this is the enemy ai script
        if (atkrange == true)
        {
            atktimerstart = true;
        }
        if (atktimerstart == true && atkgoing == false)
        {
            attacktimer += Time.deltaTime;
        }


        //checks to see if the enemy should track the player
        if (trackplayer == true)
        {
            //this sers the player as a variable in the code
            GameObject player = GameObject.FindWithTag("Player");
            //if the player is found then it starts tracking
            if (player != null)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                if (direction.x <= 0)
                {
                    Vector3 offset = new Vector3(1.5f, 0, 0);
                    Vector3 directions = (player.transform.position + offset - transform.position).normalized;
                    transform.Translate(directions * speed * Time.deltaTime);
                    transform.localScale = new Vector3(1f, 2.1669f);
                }
                if (direction.x >= 0)
                {
                    Vector3 offset = new Vector3(-1.5f, 0, 0);
                    Vector3 directions = (player.transform.position + offset - transform.position).normalized;
                    transform.Translate(directions * speed * Time.deltaTime);
                    transform.localScale = new Vector3(-1f, 2.1669f);
                }
            }
        }
        if (health == 0)
        {
            Destroy(gameObject);
        }
        //this is the attack ai part
        if (attacktimer >= attackcooldown)
        {
            Debug.Log("Attacking now");
            attack();
            setrandomcooldown();
            atkgoing = true;
        }
        if (attackcooldown > 2)
        {
            parry = true;
        }

        if (atimer == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                sr.color = Color.white;
                TurnOnCircle();
                atktime = true;
                atimer = false;
                timer = 0.5f;
            }
        }
        if (atktime == true)
        {
            atklength -= Time.deltaTime;
        }
        if (atklength <= 0)
        {
            atktime = false;
            TurnOffCircle();
            atklength = 0.5f;
            atkgoing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHB") && parry == false && hit == false)
        {
            health -= 1;
            hit = true;
            setrandomcooldown();
            Invoke("iframes", 0.3f);
        }
        if (collision.CompareTag("PlayerHB") && parry == true)
        {
            parry = false;
        }
    }
    void setrandomcooldown()
    {
        attackcooldown = Random.Range(1f, 2.6f);
        attacktimer = 0f;
    }
    void attack()
    {
        sr.color = Color.red;
        atimer = true;
        atkgoing = true;
    }
    void iframes()
    {
        hit = false;
    }
    void TurnOnCircle()
    {
        circle.SetActive(true);
    }
    void TurnOffCircle()
    {
        circle.SetActive(false);
    }
}
