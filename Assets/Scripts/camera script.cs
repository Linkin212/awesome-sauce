using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camerascript : MonoBehaviour
{

    void Start()
    {

    }   
    // Update is called once per frame
    void Update()
    {

        GameObject Player = GameObject.FindWithTag("Player");
        Vector3 newPosition = new Vector3(Player.transform.position.x,Player.transform.position.y,-10);
        transform.position = newPosition;
    }
}
