using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doortp : MonoBehaviour
{
    public Transform tpoint;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = tpoint.position;
        }
    }
}
