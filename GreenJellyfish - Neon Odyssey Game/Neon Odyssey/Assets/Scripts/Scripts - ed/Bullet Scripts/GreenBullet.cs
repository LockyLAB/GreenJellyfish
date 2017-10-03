﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider col)
    {
        //if bullet is same colour as enemy, destroy enemy, destroy bullet
        if (col.gameObject.tag == "green")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        //if bullet collides with objects under "collision" layer, destroy bullet
        if (col.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        //if enemy is not bullet colour, destroy bullet
        else if (col.gameObject.tag == "pink")
        {
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "orange")
        {
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "yellow")
        {
            Destroy(gameObject);
        }
    }
}
