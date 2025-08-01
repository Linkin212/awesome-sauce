using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powboompow : MonoBehaviour
{
    public bool parrywindow = false;
    public float parrytime = 1.5f;
    public float parrycd = 3;
    public bool parrycdactive = false;
    public int Health = 3;
    public GameObject circle;
    public float atklength = 0.5f;
    public bool atktimer = false;
    public Animator an;

    void Update()
    {

        //if (stunned )
        //{
        //    return;
        //} 

        //attack button
        if (Input.GetKeyDown(KeyCode.Mouse0) && parrywindow == false)
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
        if (Input.GetKeyDown(KeyCode.F) && parrycdactive == false && parrywindow == false)
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
            parrytime = 1.5f;
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
}
