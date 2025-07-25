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
    // Update is called once per frame
    void Update()
    {

        //if (stunned )
        //{
        //    return;
        //} 
            
        if (Input.GetKeyDown(KeyCode.F) && parrycdactive == false && parrywindow == false)
        {   
            parrywindow = true;
            Debug.Log("Parry work");
        }   
            
        if (parrywindow == true)
        {   
            parrytime -= Time.deltaTime;
            
        }   
            
        if (parrytime <= 0)
        {
            parrywindow = false;
            parrycdactive = true;
            parrytime = 1.5f;
        }

        if (parrycdactive == true) 
        {
            parrycd -= Time.deltaTime;
        }

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
