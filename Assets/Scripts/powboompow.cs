using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class powboompow : MonoBehaviour
{
    public bool parrywindow = false;
    public float parrytime = .2f;
    public float parrycd = 3;
    public bool parrycdactive = false;
    public int Health = 3;
    public GameObject circle;
    public float atklength = 0.5f;
    public bool atktimer = false;
    public Animator an;
    public bool Hit = false;
    public Transform tp1;
    public Transform tp2;
    public Transform tp3;
    public int currenttp = 0;

    void Update()
    {

        //if (stunned )
        //{
        //    return;
        //} 

        //attack button
        if (Input.GetKeyDown(KeyCode.J) && parrywindow == false)
        {
            TurnOnCircle();
            atktimer = true;
            an.SetBool("isattacking", true);
        }

        if (atktimer == true)
        {
            atklength -= Time.deltaTime;
        }

        if (atklength <= 0)
        {
            atktimer = false;
            TurnOffCircle();
            atklength = 0.5f;
            an.SetBool("isattacking", false);
        }

        //start of the parry makes sure a parry isnt currently happening
        if (Input.GetKeyDown(KeyCode.K) && parrycdactive == false && parrywindow == false)
        {
            //starts the parry
            parrywindow = true;
            Debug.Log("Parry work");
        }   
        
        //starts the timer for how long the parry is
        if (parrywindow == true)
        {   
            parrytime -= Time.deltaTime;  
        }   
        
        //checks for when the parry ends
        if (parrytime <= 0)
        {
            //ends the parry and starts the cooldown alse resets the parry time
            parrywindow = false;
            parrycdactive = true;
            parrytime = .2f;
        }
        
        //starts parry cooldown timer
        if (parrycdactive == true) 
        {
            parrycd -= Time.deltaTime;
        }

        //once parry cooldown is over it allows another parry
        if (parrycd <= 0)
        {
            parrycdactive = false;
            parrycd = 3;
        }
        if (Hit == true)
        {
            Invoke("ResetHit", 0.3f);
        }
        if (Health <= 0)
        {
            if (currenttp == 1)
            {
                transform.position = tp1.position;
            }
            else if (currenttp == 2)
            {
                transform.position = tp2.position;
            }
            else if (currenttp == 3)
            {
                transform.position = tp3.position;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attacking" && parrywindow == true)
        {

        }
    }
    void TurnOnCircle()
    {
        circle.SetActive(true);
    }
    void TurnOffCircle() 
    {
        circle.SetActive(false);
    }
    void ResetHit()
    {
        Hit = false;
    }
}
